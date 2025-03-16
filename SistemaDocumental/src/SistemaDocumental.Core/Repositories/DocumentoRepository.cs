using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly List<Documento> _documentos = new List<Documento>();

        public Documento? ObtenerPorID(int id)
        {
            return _documentos.FirstOrDefault(d => d.ID_Documento == id);
        }

        public List<Documento> ObtenerTodos()
        {
            return _documentos;
        }

        public List<Documento> BuscarPorTitulo(string titulo)
        {
            return _documentos.Where(d => d.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Documento> BuscarPorCategoria(Categoria categoria)
        {
            return _documentos.Where(d => d.CategoriasDocumento.Any(c => c.Categoria == categoria)).ToList();
        }

        public List<Documento> BuscarPorTipo(TipoDocumento tipo)
        {
            return _documentos.Where(d => d.TipoDocumento == tipo).ToList();
        }

        public List<Documento> BuscarPorAutor(Usuario usuario)
        {
            return _documentos.Where(d => d.UsuarioOrigen == usuario).ToList();
        }

        public List<Documento> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _documentos.Where(d => d.Fecha_Subida >= fechaInicio && d.Fecha_Subida <= fechaFin).ToList();
        }

        public List<Documento> OrdenarPorRelevancia()
        {
            return _documentos.OrderByDescending(d => d.Relevancia).ToList();
        }

        public List<Documento> OrdenarPorFecha(bool descendente)
        {
            return descendente ? _documentos.OrderByDescending(d => d.Fecha_Subida).ToList() : _documentos.OrderBy(d => d.Fecha_Subida).ToList();
        }

        public void ActualizarIndiceBusqueda()
        {
            foreach (var doc in _documentos)
            {
                doc.Necesita_Actualizar_Index = false;
            }
        }

        public void Actualizar(Documento documento)
        {
            var index = _documentos.FindIndex(d => d.ID_Documento == documento.ID_Documento);
            if (index != -1)
            {
                _documentos[index] = documento;
            }
        }

        // MÉTODOS AGREGADOS SEGÚN EL DIAGRAMA:

        public void CambiarEstado(int idDocumento, EstadoDocumento nuevoEstado)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Estado = nuevoEstado;
            }
        }

        public List<Categoria> ObtenerCategorias(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            return documento?.CategoriasDocumento.Select(dc => dc.Categoria).ToList() ?? new List<Categoria>();
        }

        public void AsignarCategoria(int idDocumento, Categoria categoria)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                var docCategoria = new DocumentoCategoria(documento.ID_Documento, documento, categoria.ID_Categoria, categoria);
                documento.CategoriasDocumento.Add(docCategoria);
            }
        }

        public void EliminarCategoria(int idDocumento, Categoria categoria)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                var docCategoria = documento.CategoriasDocumento.FirstOrDefault(dc => dc.ID_Categoria == categoria.ID_Categoria);
                if (docCategoria != null)
                {
                    documento.CategoriasDocumento.Remove(docCategoria);
                }
            }
        }

        public bool ValidarFormato(int idDocumento, string formato)
        {
            var documento = ObtenerPorID(idDocumento);
            return documento != null && Enum.TryParse(formato, out FormatoDescargable _);
        }

        public List<VersionHistorial> ObtenerVersiones(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            return documento?.VersionesHistorial.ToList() ?? new List<VersionHistorial>();
        }

        public void CrearNuevaVersion(int idDocumento, Usuario usuario, TipoAccion accion)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                var nuevaVersion = new VersionHistorial
                {
                    ID_Documento = documento.ID_Documento,
                    Documento = documento,
                    UsuarioModificador = usuario,
                    Fecha = DateTime.Now,
                    Titulo = documento.Titulo,
                    Descripcion = "Nueva versión creada",
                    Contenido = new byte[0],
                    Hash_Integridad = documento.Hash_Integridad
                };

                documento.VersionesHistorial.Add(nuevaVersion);
            }
        }

        public void BloquearDocumento(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Bloqueado = true;
            }
        }

        public void DesbloquearDocumento(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Bloqueado = false;
            }
        }

        public bool VerificarIntegridad(int idDocumento, string hash)
        {
            var documento = ObtenerPorID(idDocumento);
            return documento != null && documento.Hash_Integridad == hash;
        }

        public void ActualizarRelevancia(int idDocumento, float nuevaRelevancia)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Relevancia = nuevaRelevancia;
            }
        }

        public void MarcarParaReindexacion(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Necesita_Actualizar_Index = true;
            }
        }

        public void ValidarDocumento(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            if (documento != null)
            {
                documento.Validado = true;
                documento.Fecha_Validacion = DateTime.Now;
            }
        }

        public bool EsVencido(int idDocumento)
        {
            var documento = ObtenerPorID(idDocumento);
            return documento != null && documento.Fecha_Vencimiento.HasValue && documento.Fecha_Vencimiento.Value < DateTime.Now;
        }
                public void GuardarDocumento(Documento documento)
        {
            var existente = ObtenerPorID(documento.ID_Documento);
            if (existente == null)
            {
                _documentos.Add(documento);
            }
            else
            {
                var index = _documentos.FindIndex(d => d.ID_Documento == documento.ID_Documento);
                _documentos[index] = documento;
            }
        }

        public void EliminarDocumento(int id)
        {
            var documento = ObtenerPorID(id);
            if (documento != null)
            {
                _documentos.Remove(documento);
            }
        }
        
    }
}
