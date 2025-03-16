using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IDireccionRepository
    {
        Direccion? ObtenerPorID(int id);
        List<Direccion> ObtenerTodas();
        void Agregar(Direccion direccion);
        void Eliminar(Direccion direccion);
    }
}
