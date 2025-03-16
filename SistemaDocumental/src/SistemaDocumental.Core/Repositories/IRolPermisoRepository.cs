using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IRolPermisoRepository
    {
        List<Permiso> ObtenerPermisosDeRol(Roles rol);
        void AsignarPermiso(Roles rol, Permiso permiso);
        void EliminarPermiso(Roles rol, Permiso permiso);
        bool TienePermiso(Roles rol, Permiso permiso);
    }
}
