using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Repositories
{
    public interface IHistorialPermisosRepository
    {
        HistorialPermisos? ObtenerPorID(int id);
        List<HistorialPermisos> ObtenerTodos();
        List<HistorialPermisos> ObtenerPorUsuario(int idUsuario);
        List<HistorialPermisos> ObtenerPorPermiso(int idPermiso);
        List<HistorialPermisos> ObtenerPorGrupo(int idGrupo);
        List<HistorialPermisos> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin);
        void RegistrarCambio(HistorialPermisos historial);
    }
}
