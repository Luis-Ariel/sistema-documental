using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class RolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public int ObtenerID(Roles rol) => rol.ID_Grupo;
        public string ObtenerNombre(Roles rol) => rol.Nombre_Grupo;
        public int ObtenerNivel(Roles rol) => rol.Nivel;
        public string ObtenerDescripcion(Roles rol) => rol.Descripcion;
        public DateTime ObtenerFechaCreacion(Roles rol) => rol.Fecha_Creacion;
        public Roles? ObtenerRolPadre(Roles rol) => rol.RolPadre;

        public void EstablecerRolPadre(int idRol, int idRolPadre)
        {
            var rol = _rolesRepository.ObtenerPorID(idRol);
            var rolPadre = _rolesRepository.ObtenerPorID(idRolPadre);

            if (rol != null && rolPadre != null)
            {
                _rolesRepository.EstablecerRolPadre(rol, rolPadre);
            }
        }

        public bool EsSuperiorA(int idRol, int idOtroRol)
        {
            var rol = _rolesRepository.ObtenerPorID(idRol);
            var otroRol = _rolesRepository.ObtenerPorID(idOtroRol);

            return rol != null && otroRol != null && rol.Nivel > otroRol.Nivel;
        }

        public bool EliminarRol(int idRol)
        {
            var rol = _rolesRepository.ObtenerPorID(idRol);
            if (rol == null) return false;

            return _rolesRepository.EliminarRol(rol);
        }

        public List<Roles> ObtenerTodosLosRoles() => _rolesRepository.ObtenerTodos();

        public Roles? ObtenerPorID(int id) => _rolesRepository.ObtenerPorID(id);
    }
}
