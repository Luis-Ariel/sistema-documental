using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Repositories
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly List<Permiso> _permisos = new List<Permiso>();

        public void ModificarNombre(Permiso permiso, string nuevoNombre)
        {
            var permisoExistente = _permisos.FirstOrDefault(p => p == permiso);
            if (permisoExistente != null)
            {
                permisoExistente.Nombre = nuevoNombre;
            }
        }

        public void ModificarNivelAcceso(Permiso permiso, string nuevoNivel)
        {
            if (Enum.TryParse<NivelAcceso>(nuevoNivel, out NivelAcceso nivelAcceso))
            {
                permiso.Nivel_Acceso = nivelAcceso;
            }
        }

        public bool EliminarPermiso(Permiso permiso)
        {
            if (EstaAsignado(permiso)) return false; // No se puede eliminar si está asignado

            return _permisos.Remove(permiso);
        }

        public bool EstaAsignado(Permiso permiso)
        {
            return permiso.HistorialModificaciones.Any() || permiso.RolesAsignados.Any();
        }
    }
}
