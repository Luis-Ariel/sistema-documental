using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities.Enums;


namespace SistemaDocumental.Core.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public Usuario? ObtenerPorID(int id)
        {
            return _usuarios.FirstOrDefault(u => u.ID_Usuario == id);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public List<Documento> BuscarDocumentosPorAutor(Usuario autor)
        {
            return autor.DocumentosCreados.ToList();
        }

        public Oficina? ObtenerOficina(int idUsuario)
        {
            var usuario = ObtenerPorID(idUsuario);
            return usuario?.Oficina ?? null; // Devuelve null si usuario u oficina son null
        }

        public CentroCostos? ObtenerCentroCostos(int idUsuario)
        {
            var usuario = ObtenerPorID(idUsuario);
            return usuario?.CentroCostos ?? null; // Devuelve null si usuario o centro de costos son null
        }

        public void CambiarOficina(int idUsuario, Oficina nuevaOficina)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null)
            {
                usuario.Oficina = nuevaOficina;
            }
        }

        public void CambiarCentroCostos(int idUsuario, CentroCostos nuevoCentro)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null)
            {
                usuario.CentroCostos = nuevoCentro;
            }
        }

        // Métodos agregados para la relación N-1 con Roles

        public Roles? ObtenerRol(int idUsuario)
        {
            var usuario = ObtenerPorID(idUsuario);
            return usuario?.Grupo ?? null; // Devuelve null si usuario o rol son null
        }

        public void CambiarRol(int idUsuario, Roles nuevoRol)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null)
            {
                usuario.Grupo = nuevoRol;
            }
        }

        public void SubirDocumento(int idUsuario, Documento documento)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null)
            {
                documento.UsuarioOrigen = usuario;
                usuario.DocumentosCreados.Add(documento);
            }
        }

        public void ModificarDocumento(int idUsuario, Documento documento)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null)
            {
                documento.UsuarioModificador = usuario;
                usuario.DocumentosModificados.Add(documento);
            }
        }

        public void ValidarDocumento(int idUsuario, Documento documento)
        {
            var usuario = ObtenerPorID(idUsuario);
            if (usuario != null && usuario.Activo)
            {
                documento.Validado = true;
            }
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
            return usuario.Notificaciones.ToList();
        }

        public List<AlertaDestinatario> RecibirAlertas(Usuario usuario)
        {
            return usuario.AlertasRecibidas.ToList();
        }


        public void MarcarNotificacionLeida(Usuario usuario, NotificacionEvento notificacion)
        {
            var noti = usuario.Notificaciones.FirstOrDefault(n => n.ID_Notificacion == notificacion.ID_Notificacion);
            if (noti != null)
            {
                noti.Leido = true;
            }
        }

        public void MarcarTodasNotificacionesLeidas(Usuario usuario)
        {
            foreach (var notificacion in usuario.Notificaciones)
            {
                notificacion.Leido = true;
            }
        }

        public bool EstaLeida(NotificacionEvento notificacion)
        {
            return notificacion.Leido;
        }

        public void DesactivarAlertas(Usuario usuario)
        {
            usuario.AlertasRecibidas.Clear();
        }

        public void DesactivarNotificaciones(Usuario usuario)
        {
            usuario.Notificaciones.Clear();
        }
                public void GuardarUsuario(Usuario usuario)
        {
            var existente = ObtenerPorID(usuario.ID_Usuario);
            if (existente == null)
            {
                _usuarios.Add(usuario);
            }
            else
            {
                var index = _usuarios.FindIndex(u => u.ID_Usuario == usuario.ID_Usuario);
                _usuarios[index] = usuario;
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuario = ObtenerPorID(id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
        }

    }
}
