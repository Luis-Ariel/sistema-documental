using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class DireccionService
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        public int ObtenerID(Direccion direccion)
        {
            return direccion.ID_Direccion;
        }

        public string ObtenerNombre(Direccion direccion)
        {
            return direccion.Nombre_Direccion;
        }

        public List<Departamento> ObtenerDepartamentos(Direccion direccion)
        {
            return direccion.Departamentos.ToList();
        }

        public void AgregarDepartamento(Direccion direccion, Departamento departamento)
        {
            if (!direccion.Departamentos.Contains(departamento))
            {
                direccion.Departamentos.Add(departamento);
            }
        }

        public void EliminarDepartamento(Direccion direccion, Departamento departamento)
        {
            if (direccion.Departamentos.Contains(departamento))
            {
                direccion.Departamentos.Remove(departamento);
            }
        }

        public string ObtenerEstructuraCompleta(Direccion direccion)
        {
            return $"Dirección: {direccion.Nombre_Direccion}";
        }
    }
}
