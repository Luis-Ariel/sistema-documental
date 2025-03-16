using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities.Enums;


namespace SistemaDocumental.Core.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public int ObtenerID(Usuario usuario)
        {
            return usuario.ID_Usuario;
        }

        public string ObtenerNombreCompleto(Usuario usuario)
        {
            return $"{usuario.Nombre} {usuario.Apellido}";
        }

        public string ObtenerCorreo(Usuario usuario)
        {
            return usuario.Correo;
        }

        public bool EstaActivo(Usuario usuario)
        {
            return usuario.Activo;
        }

        public List<Documento> BuscarDocumentosCreados(Usuario usuario)
        {
            return usuario.DocumentosCreados.ToList();
        }

        public List<Documento> BuscarDocumentosModificados(Usuario usuario)
        {
            return usuario.DocumentosModificados.ToList();
        }

        public List<Documento> BuscarDocumentosPorAutor(Usuario autor)
        {
            return _usuarioRepository.BuscarDocumentosPorAutor(autor);
        }

        public Oficina ObtenerOficina(Usuario usuario)
        {
            return usuario.Oficina;
        }

        public CentroCostos ObtenerCentroCostos(Usuario usuario)
        {
            return usuario.CentroCostos;
        }

        public void CambiarOficina(Usuario usuario, Oficina nuevaOficina)
        {
            usuario.Oficina = nuevaOficina;
        }

        public void CambiarCentroCostos(Usuario usuario, CentroCostos nuevoCentro)
        {
            usuario.CentroCostos = nuevoCentro;
        }

        public string ObtenerEstructuraCompleta(Usuario usuario)
        {
            return $"Usuario: {usuario.Nombre} {usuario.Apellido}, Oficina: {usuario.Oficina.Nombre_Oficina}, Centro de Costos: {usuario.CentroCostos.ID_Centro_Costos}";
        }

        // Métodos agregados para la relación N-1 con Roles

        public Roles ObtenerRol(Usuario usuario)
        {
            return usuario.Grupo;
        }

        public void CambiarRol(Usuario usuario, Roles nuevoRol)
        {
            usuario.Grupo = nuevoRol;
        }

        public void SubirDocumento(Usuario usuario, Documento documento)
        {
            documento.UsuarioOrigen = usuario;
            usuario.DocumentosCreados.Add(documento);
        }

        public void ModificarDocumento(Usuario usuario, Documento documento)
        {
            documento.UsuarioModificador = usuario;
            usuario.DocumentosModificados.Add(documento);
        }

        public void ValidarDocumento(Usuario usuario, Documento documento)
        {
            if (!usuario.Activo) return;
            documento.Validado = true;
        }

        public void ClasificarDocumento(Documento documento, Categoria categoria)
        {
            var docCategoria = new DocumentoCategoria(documento.ID_Documento, documento, categoria.ID_Categoria, categoria);
            documento.CategoriasDocumento.Add(docCategoria);
        }


        public void EliminarDocumento(Documento documento)
        {
            documento.Estado = EstadoDocumento.Eliminado;
        }

        public List<NotificacionEvento> RecibirNotificaciones(Usuario usuario)
        {
            return _usuarioRepository.RecibirNotificaciones(usuario);
        }

        public List<AlertaDocumento> RecibirAlertas(Usuario usuario)
        {
            return _usuarioRepository.RecibirAlertas(usuario)
                             .Select(a => a.Alerta) // Extrae las alertas desde AlertaDestinatario
                             .ToList();
        }

        public void MarcarNotificacionLeida(Usuario usuario, NotificacionEvento notificacion)
        {
            _usuarioRepository.MarcarNotificacionLeida(usuario, notificacion);
        }

        public void MarcarTodasNotificacionesLeidas(Usuario usuario)
        {
            _usuarioRepository.MarcarTodasNotificacionesLeidas(usuario);
        }

        public void DesactivarAlertas(Usuario usuario)
        {
            _usuarioRepository.DesactivarAlertas(usuario);
        }

        public void DesactivarNotificaciones(Usuario usuario)
        {
            _usuarioRepository.DesactivarNotificaciones(usuario);
        }
        public void GuardarUsuario(Usuario usuario)
        {
            _usuarioRepository.GuardarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _usuarioRepository.EliminarUsuario(id);
        }

    }
    
}
