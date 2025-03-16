using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerPorID(int id);
        List<Usuario> ObtenerTodos();
        List<Documento> BuscarDocumentosPorAutor(Usuario autor);
        Oficina? ObtenerOficina(int idUsuario);
        CentroCostos? ObtenerCentroCostos(int idUsuario);
        void CambiarOficina(int idUsuario, Oficina nuevaOficina);
        void CambiarCentroCostos(int idUsuario, CentroCostos nuevoCentro);
        // Métodos agregados para la relación N-1 con Roles
        Roles? ObtenerRol(int idUsuario);
        void CambiarRol(int idUsuario, Roles nuevoRol);
        void SubirDocumento(int idUsuario, Documento documento);
        void ModificarDocumento(int idUsuario, Documento documento);
        void ValidarDocumento(int idUsuario, Documento documento);
        void ClasificarDocumento(Documento documento, Categoria categoria);
        void EliminarDocumento(Documento documento);
        List<NotificacionEvento> RecibirNotificaciones(Usuario usuario);
        void MarcarNotificacionLeida(Usuario usuario, NotificacionEvento notificacion);
        void MarcarTodasNotificacionesLeidas(Usuario usuario);
        void DesactivarAlertas(Usuario usuario);
        void DesactivarNotificaciones(Usuario usuario);
        public List<AlertaDestinatario> RecibirAlertas(Usuario usuario);
        void GuardarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
    }
}
