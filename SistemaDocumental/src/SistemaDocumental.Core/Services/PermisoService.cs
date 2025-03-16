using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;

namespace SistemaDocumental.Core.Services
{
    public class PermisoService
    {
        private readonly IPermisoRepository _permisoRepository;

        public PermisoService(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        public int ObtenerID(Permiso permiso)
        {
            return permiso.ID_Permiso;
        }

        public string ObtenerNombre(Permiso permiso)
        {
            return permiso.Nombre;
        }

        public string ObtenerNivel(Permiso permiso)
        {
            return permiso.Nivel_Acceso.ToString();
        }

        public DateTime ObtenerFechaCreacion(Permiso permiso)
        {
            return permiso.Fecha_Creacion;
        }

        public void ModificarNombre(Permiso permiso, string nuevoNombre)
        {
            _permisoRepository.ModificarNombre(permiso, nuevoNombre);
        }

        public void ModificarNivelAcceso(Permiso permiso, string nuevoNivel)
        {
            _permisoRepository.ModificarNivelAcceso(permiso, nuevoNivel);
        }

        public bool EliminarPermiso(Permiso permiso)
        {
            return _permisoRepository.EliminarPermiso(permiso);
        }

        public bool EstaAsignado(Permiso permiso)
        {
            return _permisoRepository.EstaAsignado(permiso);
        }
    }
}
