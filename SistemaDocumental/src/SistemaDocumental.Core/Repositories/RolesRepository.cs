using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly List<Roles> _roles = new List<Roles>();

        public Roles? ObtenerPorID(int id) => _roles.FirstOrDefault(r => r.ID_Grupo == id);

        public List<Roles> ObtenerTodos() => _roles;

        public void EstablecerRolPadre(Roles rol, Roles rolPadre)
        {
            if (_roles.Contains(rol) && _roles.Contains(rolPadre))
            {
                rol.RolPadre = rolPadre;
                rol.ID_GrupoPadre = rolPadre.ID_Grupo;
            }
        }

        public bool EliminarRol(Roles rol)
        {
            if (rol.Usuarios.Any() || rol.HistorialPermisos.Any() || rol.PermisosRol.Any())
            {
                return false; // No se puede eliminar si hay dependencias activas
            }
            return _roles.Remove(rol);
        }
    }
}
