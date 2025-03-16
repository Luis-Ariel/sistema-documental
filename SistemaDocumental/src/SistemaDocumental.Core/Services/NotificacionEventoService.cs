using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class NotificacionEventoService
    {
        private readonly INotificacionEventoRepository _notificacionRepository;

        public NotificacionEventoService(INotificacionEventoRepository notificacionRepository)
        {
            _notificacionRepository = notificacionRepository;
        }

        public int ObtenerID(NotificacionEvento notificacion)
        {
            return notificacion.ID_Notificacion;
        }

        public Usuario ObtenerUsuario(NotificacionEvento notificacion)
        {
            return notificacion.Usuario;
        }

        public string ObtenerMensaje(NotificacionEvento notificacion)
        {
            return notificacion.Mensaje;
        }

        public string ObtenerEstado(NotificacionEvento notificacion)
        {
            return notificacion.Estado.ToString();
        }

        public DateTime ObtenerFechaCreacion(NotificacionEvento notificacion)
        {
            return notificacion.Fecha_Creacion;
        }

        public DateTime? ObtenerFechaEnvio(NotificacionEvento notificacion)
        {
            return notificacion.Fecha_Envio;
        }

        public void MarcarComoLeido(NotificacionEvento notificacion)
        {
            notificacion.Leido = true;
            _notificacionRepository.Actualizar(notificacion);
        }

        public void MarcarTodasComoLeidas(int idUsuario)
        {
            var notificaciones = _notificacionRepository.ObtenerPorUsuario(idUsuario);
            foreach (var notificacion in notificaciones)
            {
                notificacion.Leido = true;
            }
        }

        public void CancelarNotificacion(NotificacionEvento notificacion)
        {
            notificacion.Estado = EstadoNotificacion.Cancelado;
            _notificacionRepository.Actualizar(notificacion);
        }

        public void EnviarNotificacion(NotificacionEvento notificacion)
        {
            if (notificacion.Estado == EstadoNotificacion.Pendiente)
            {
                notificacion.Estado = EstadoNotificacion.Enviado;
                notificacion.Fecha_Envio = DateTime.Now;
                _notificacionRepository.Actualizar(notificacion);
            }
        }

        public void ProcesarNotificacionesProgramadas()
        {
            var pendientes = _notificacionRepository.ObtenerPendientes();
            foreach (var notificacion in pendientes)
            {
                if (notificacion.Fecha_Programada <= DateTime.Now)
                {
                    EnviarNotificacion(notificacion);
                }
            }
        }
    }
}
