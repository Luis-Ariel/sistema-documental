using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class HistorialPermisosService
    {
        private readonly IHistorialPermisosRepository _historialPermisosRepository;

        public HistorialPermisosService(IHistorialPermisosRepository historialPermisosRepository)
        {
            _historialPermisosRepository = historialPermisosRepository;
        }

        public int ObtenerID(HistorialPermisos historial)
        {
            return historial.ID_Historial;
        }

        public DateTime ObtenerFecha(HistorialPermisos historial)
        {
            return historial.Fecha;
        }

        public Usuario ObtenerUsuario(HistorialPermisos historial)
        {
            return historial.Usuario;
        }

        public Permiso ObtenerPermiso(HistorialPermisos historial)
        {
            return historial.Permiso;
        }

        public Roles? ObtenerGrupo(HistorialPermisos historial)
        {
            return historial.Grupo;
        }

        public TipoCambioPermiso ObtenerTipoCambio(HistorialPermisos historial)
        {
            return historial.Tipo_Cambio;
        }

        public NivelAcceso ObtenerNivelAcceso(HistorialPermisos historial)
        {
            return historial.Nivel_Acceso;
        }

        public string ObtenerDescripcion(HistorialPermisos historial)
        {
            return historial.Descripcion;
        }

        public void RegistrarCambio(HistorialPermisos historial)
        {
            _historialPermisosRepository.RegistrarCambio(historial);
        }

        public List<HistorialPermisos> ObtenerHistorialPorUsuario(int idUsuario)
        {
            return _historialPermisosRepository.ObtenerPorUsuario(idUsuario);
        }

        public List<HistorialPermisos> ObtenerHistorialPorPermiso(int idPermiso)
        {
            return _historialPermisosRepository.ObtenerPorPermiso(idPermiso);
        }

        public List<HistorialPermisos> ObtenerHistorialPorGrupo(int idGrupo)
        {
            return _historialPermisosRepository.ObtenerPorGrupo(idGrupo);
        }

        public List<HistorialPermisos> ObtenerHistorialPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _historialPermisosRepository.ObtenerPorFecha(fechaInicio, fechaFin);
        }
    }
}
