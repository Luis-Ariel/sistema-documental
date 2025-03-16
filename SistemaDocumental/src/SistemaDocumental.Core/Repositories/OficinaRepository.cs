using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class OficinaRepository : IOficinaRepository
    {
        private readonly List<Oficina> _oficinas = new List<Oficina>();

        public Oficina? ObtenerPorID(int id)
        {
            return _oficinas.FirstOrDefault(o => o.ID_Oficina == id);
        }

        public List<Oficina> ObtenerTodas()
        {
            return _oficinas;
        }

        public void Agregar(Oficina oficina)
        {
            _oficinas.Add(oficina);
        }

        public void Eliminar(Oficina oficina)
        {
            _oficinas.Remove(oficina);
        }
    }
}
