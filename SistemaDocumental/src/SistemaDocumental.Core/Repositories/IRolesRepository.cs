using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IRolesRepository
    {
        Roles? ObtenerPorID(int id);
        List<Roles> ObtenerTodos();
        void EstablecerRolPadre(Roles rol, Roles rolPadre);
        bool EliminarRol(Roles rol);
    }
}
