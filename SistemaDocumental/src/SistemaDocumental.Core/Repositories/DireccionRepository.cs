using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly List<Direccion> _direcciones = new List<Direccion>();

        public Direccion? ObtenerPorID(int id)
        {
            return _direcciones.FirstOrDefault(d => d.ID_Direccion == id);
        }

        public List<Direccion> ObtenerTodas()
        {
            return _direcciones;
        }

        public void Agregar(Direccion direccion)
        {
            _direcciones.Add(direccion);
        }

        public void Eliminar(Direccion direccion)
        {
            _direcciones.Remove(direccion);
        }
    }
}
