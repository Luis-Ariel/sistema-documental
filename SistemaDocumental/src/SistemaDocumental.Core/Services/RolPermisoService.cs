using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class RolPermisoService
    {
        private readonly IRolPermisoRepository _rolPermisoRepository;

        public RolPermisoService(IRolPermisoRepository rolPermisoRepository)
        {
            _rolPermisoRepository = rolPermisoRepository;
        }

        public DateTime ObtenerFechaAsignacion(RolPermiso rolPermiso)
        {
            return rolPermiso.Fecha_Asignacion;
        }

        public Roles ObtenerRol(RolPermiso rolPermiso)
        {
            return rolPermiso.Rol;
        }

        public Permiso ObtenerPermiso(RolPermiso rolPermiso)
        {
            return rolPermiso.Permiso;
        }

        public List<Permiso> ObtenerPermisosDeRol(Roles rol)
        {
            return _rolPermisoRepository.ObtenerPermisosDeRol(rol);
        }

        public void AsignarPermiso(Roles rol, Permiso permiso)
        {
            _rolPermisoRepository.AsignarPermiso(rol, permiso);
        }

        public void EliminarPermiso(Roles rol, Permiso permiso)
        {
            _rolPermisoRepository.EliminarPermiso(rol, permiso);
        }

        public bool TienePermiso(Roles rol, Permiso permiso)
        {
            return _rolPermisoRepository.TienePermiso(rol, permiso);
        }
    }
}
