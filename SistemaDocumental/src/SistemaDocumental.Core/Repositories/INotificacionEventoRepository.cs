using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface INotificacionEventoRepository
    {
        NotificacionEvento? ObtenerPorID(int id);
        List<NotificacionEvento> ObtenerPendientes();
        List<NotificacionEvento> ObtenerPorUsuario(int idUsuario);
        List<NotificacionEvento> ObtenerPorGrupo(int idGrupo);
        void Agregar(NotificacionEvento notificacion);
        void Actualizar(NotificacionEvento notificacion);
    }
}
