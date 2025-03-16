using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class HistorialPermisosRepository : IHistorialPermisosRepository
    {
        private readonly List<HistorialPermisos> _historial = new List<HistorialPermisos>();

        public HistorialPermisos? ObtenerPorID(int id)
        {
            return _historial.FirstOrDefault(h => h.ID_Historial == id);
        }

        public List<HistorialPermisos> ObtenerTodos()
        {
            return _historial;
        }

        public List<HistorialPermisos> ObtenerPorUsuario(int idUsuario)
        {
            return _historial.Where(h => h.ID_Usuario == idUsuario).ToList();
        }

        public List<HistorialPermisos> ObtenerPorPermiso(int idPermiso)
        {
            return _historial.Where(h => h.ID_Permiso == idPermiso).ToList();
        }

        public List<HistorialPermisos> ObtenerPorGrupo(int idGrupo)
        {
            return _historial.Where(h => h.ID_Grupo == idGrupo).ToList();
        }

        public List<HistorialPermisos> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _historial.Where(h => h.Fecha >= fechaInicio && h.Fecha <= fechaFin).ToList();
        }

        public void RegistrarCambio(HistorialPermisos historial)
        {
            _historial.Add(historial);
        }
    }
}
