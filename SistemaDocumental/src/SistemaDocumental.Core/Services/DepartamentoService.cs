using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class DepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public int ObtenerID(Departamento departamento)
        {
            return departamento.ID_Departamento;
        }

        public string ObtenerNombre(Departamento departamento)
        {
            return departamento.Nombre_Departamento;
        }

        public string ObtenerDescripcion(Departamento departamento)
        {
            return departamento.Descripcion;
        }

        public Direccion ObtenerDireccion(Departamento departamento)
        {
            return departamento.Direccion;
        }

        public List<Seccion> ObtenerSecciones(Departamento departamento)
        {
            return departamento.Secciones.ToList();
        }

        public void AgregarSeccion(Departamento departamento, Seccion seccion)
        {
            if (!departamento.Secciones.Contains(seccion))
            {
                departamento.Secciones.Add(seccion);
            }
        }

        public void EliminarSeccion(Departamento departamento, Seccion seccion)
        {
            if (departamento.Secciones.Contains(seccion))
            {
                departamento.Secciones.Remove(seccion);
            }
        }

        public string ObtenerEstructuraCompleta(Departamento departamento)
        {
            return $"{departamento.Direccion.Nombre_Direccion} > {departamento.Nombre_Departamento}";
        }
    }
}
