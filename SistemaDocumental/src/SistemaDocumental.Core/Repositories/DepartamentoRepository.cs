using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly List<Departamento> _departamentos = new List<Departamento>();

        public Departamento? ObtenerPorID(int id)
        {
            return _departamentos.FirstOrDefault(d => d.ID_Departamento == id);
        }

        public List<Departamento> ObtenerTodos()
        {
            return _departamentos;
        }

        public void Agregar(Departamento departamento)
        {
            _departamentos.Add(departamento);
        }

        public void Eliminar(Departamento departamento)
        {
            _departamentos.Remove(departamento);
        }
    }
}
