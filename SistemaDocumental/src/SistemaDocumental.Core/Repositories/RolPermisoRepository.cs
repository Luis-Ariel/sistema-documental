using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class RolPermisoRepository : IRolPermisoRepository
    {
        private readonly List<RolPermiso> _rolPermisos = new List<RolPermiso>();

        public List<Permiso> ObtenerPermisosDeRol(Roles rol)
        {
            return _rolPermisos
                .Where(rp => rp.Rol == rol)
                .Select(rp => rp.Permiso)
                .ToList();
        }

        public void AsignarPermiso(Roles rol, Permiso permiso)
        {
            if (!_rolPermisos.Any(rp => rp.Rol == rol && rp.Permiso == permiso))
            {
                _rolPermisos.Add(new RolPermiso { Rol = rol, Permiso = permiso, Fecha_Asignacion = System.DateTime.Now });
            }
        }

        public void EliminarPermiso(Roles rol, Permiso permiso)
        {
            var rolPermiso = _rolPermisos.FirstOrDefault(rp => rp.Rol == rol && rp.Permiso == permiso);
            if (rolPermiso != null)
            {
                _rolPermisos.Remove(rolPermiso);
            }
        }

        public bool TienePermiso(Roles rol, Permiso permiso)
        {
            return _rolPermisos.Any(rp => rp.Rol == rol && rp.Permiso == permiso);
        }
    }
}
