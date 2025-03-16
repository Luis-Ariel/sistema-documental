using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Services
{
    public class DocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public int ObtenerID(Documento documento)
        {
            return documento.ID_Documento;
        }

        public string ObtenerTitulo(Documento documento)
        {
            return documento.Titulo;
        }

        public TipoDocumento ObtenerTipo(Documento documento)
        {
            return documento.TipoDocumento;
        }

        public DateTime ObtenerFechaSubida(Documento documento)
        {
            return documento.Fecha_Subida;
        }

        public DateTime? ObtenerFechaModificacion(Documento documento)
        {
            return documento.Fecha_Modificacion;
        }

        public Usuario ObtenerUsuarioOrigen(Documento documento)
        {
            return documento.UsuarioOrigen;
        }

        public Usuario? ObtenerUsuarioModificador(Documento documento)
        {
            return documento.UsuarioModificador;
        }

        public bool EstaValidado(Documento documento)
        {
            return documento.Validado;
        }

        public bool EstaBloqueado(Documento documento)
        {
            return documento.Bloqueado;
        }

        public bool NecesitaActualizarIndex(Documento documento)
        {
            return documento.Necesita_Actualizar_Index;
        }

        public DateTime? ObtenerFechaValidacion(Documento documento)
        {
            return documento.Fecha_Validacion != DateTime.MinValue ? documento.Fecha_Validacion : null;
        }

        public byte[] ObtenerFirmaElectronica(Documento documento)
        {
            return documento.Firma_Electronica;
        }

        public DateTime? ObtenerFechaVencimiento(Documento documento)
        {
            return documento.Fecha_Vencimiento != DateTime.MinValue ? documento.Fecha_Vencimiento : null;
        }

        public DateTime? ObtenerUltimaIndexacion(Documento documento)
        {
            return documento.Ultima_Indexacion != DateTime.MinValue ? documento.Ultima_Indexacion : null;
        }

        public string ObtenerFormatoDescargable(Documento documento)
        {
            return documento.Formato_Descargable.ToString();
        }

        public string ObtenerFormatoImprimible(Documento documento)
        {
            return documento.Formato_Imprimible.ToString();
        }

        public float ObtenerRelevancia(Documento documento)
        {
            return documento.Relevancia;
        }

        public string ObtenerHashIntegridad(Documento documento)
        {
            return documento.Hash_Integridad;
        }

        public List<Documento> BuscarPorTitulo(string titulo)
        {
            return _documentoRepository.BuscarPorTitulo(titulo);
        }

        public List<Documento> BuscarPorCategoria(Categoria categoria)
        {
            return _documentoRepository.BuscarPorCategoria(categoria);
        }

        public List<Documento> BuscarPorTipo(TipoDocumento tipo)
        {
            return _documentoRepository.BuscarPorTipo(tipo);
        }

        public List<Documento> BuscarPorAutor(Usuario usuario)
        {
            return _documentoRepository.BuscarPorAutor(usuario);
        }

        public List<Documento> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _documentoRepository.BuscarPorFecha(fechaInicio, fechaFin);
        }

        public List<Documento> OrdenarPorRelevancia()
        {
            return _documentoRepository.ObtenerTodos().OrderByDescending(d => d.Relevancia).ToList();
        }

        public List<Documento> OrdenarPorFecha(bool descendente)
        {
            return descendente ?
                _documentoRepository.ObtenerTodos().OrderByDescending(d => d.Fecha_Subida).ToList() :
                _documentoRepository.ObtenerTodos().OrderBy(d => d.Fecha_Subida).ToList();
        }

        public void ActualizarIndiceBusqueda()
        {
            // Lógica para actualizar la indexación de los documentos
        }

        // MÉTODOS AGREGADOS SEGÚN EL DIAGRAMA:

        public void CambiarEstado(Documento documento, string nuevoEstado)
        {
            if (Enum.TryParse(nuevoEstado, out EstadoDocumento estado))
            {
                documento.Estado = estado;
            }
        }

        public List<Categoria> ObtenerCategorias(Documento documento)
        {
            return documento.CategoriasDocumento.Select(dc => dc.Categoria).ToList();
        }

        public void AsignarCategoria(Documento documento, Categoria categoria)
        {
            var docCategoria = new DocumentoCategoria(documento.ID_Documento, documento, categoria.ID_Categoria, categoria);
            documento.CategoriasDocumento.Add(docCategoria);
        }

        public void EliminarCategoria(Documento documento, Categoria categoria)
        {
            var docCategoria = documento.CategoriasDocumento.FirstOrDefault(dc => dc.ID_Categoria == categoria.ID_Categoria);
            if (docCategoria != null)
            {
                documento.CategoriasDocumento.Remove(docCategoria);
            }
        }

        public bool ValidarFormato(Documento documento, string formato)
        {
            return Enum.TryParse(formato, out FormatoDescargable _);
        }

        public List<VersionHistorial> ObtenerVersiones(Documento documento)
        {
            return documento.VersionesHistorial.ToList();
        }

        public void CrearNuevaVersion(Documento documento, Usuario usuario, string accion)
        {
            var nuevaVersion = new VersionHistorial
            {
                ID_Documento = documento.ID_Documento,
                Documento = documento,
                UsuarioModificador = usuario,
                Fecha = DateTime.Now,
                Titulo = documento.Titulo,
                Descripcion = "Nueva versión creada",
                Contenido = new byte[0], // Aquí se definiría el contenido real
                Hash_Integridad = documento.Hash_Integridad
            };

            documento.VersionesHistorial.Add(nuevaVersion);
        }

        public void BloquearDocumento(Documento documento)
        {
            documento.Bloqueado = true;
        }

        public void DesbloquearDocumento(Documento documento)
        {
            documento.Bloqueado = false;
        }

        public bool VerificarIntegridad(Documento documento, string hash)
        {
            return documento.Hash_Integridad == hash;
        }

        public void ActualizarRelevancia(Documento documento, float nuevaRelevancia)
        {
            documento.Relevancia = nuevaRelevancia;
        }

        public void MarcarParaReindexacion(Documento documento)
        {
            documento.Necesita_Actualizar_Index = true;
        }

        public void ValidarDocumento(Documento documento)
        {
            documento.Validado = true;
            documento.Fecha_Validacion = DateTime.Now;
        }

        public bool EsVencido(Documento documento)
        {
            return documento.Fecha_Vencimiento.HasValue && documento.Fecha_Vencimiento.Value < DateTime.Now;
        }
        public void GuardarDocumento(Documento documento)
        {
            _documentoRepository.GuardarDocumento(documento);
        }

        public void EliminarDocumento(int id)
        {
            _documentoRepository.EliminarDocumento(id);
        }
    }
}
