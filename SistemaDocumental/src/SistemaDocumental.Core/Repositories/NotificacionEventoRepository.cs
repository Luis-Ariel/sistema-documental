using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class NotificacionEventoRepository : INotificacionEventoRepository
    {
        private readonly List<NotificacionEvento> _notificaciones = new List<NotificacionEvento>();

        public NotificacionEvento? ObtenerPorID(int id)
        {
            return _notificaciones.FirstOrDefault(n => n.ID_Notificacion == id);
        }

        public List<NotificacionEvento> ObtenerPendientes()
        {
            return _notificaciones.Where(n => !n.Leido && n.Estado == EstadoNotificacion.Pendiente).ToList();
        }

        public List<NotificacionEvento> ObtenerPorUsuario(int idUsuario)
        {
            return _notificaciones.Where(n => n.ID_Usuario == idUsuario).ToList();
        }

        public List<NotificacionEvento> ObtenerPorGrupo(int idGrupo)
        {
            return _notificaciones.Where(n => n.ID_Grupo == idGrupo).ToList();
        }

        public void Agregar(NotificacionEvento notificacion)
        {
            _notificaciones.Add(notificacion);
        }

        public void Actualizar(NotificacionEvento notificacion)
        {
            var index = _notificaciones.FindIndex(n => n.ID_Notificacion == notificacion.ID_Notificacion);
            if (index != -1)
            {
                _notificaciones[index] = notificacion;
            }
        }
    }
}
