using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class SeccionService
    {
        private readonly ISeccionRepository _seccionRepository;

        public SeccionService(ISeccionRepository seccionRepository)
        {
            _seccionRepository = seccionRepository;
        }

        public int ObtenerID(Seccion seccion)
        {
            return seccion.ID_Seccion;
        }

        public string ObtenerNombre(Seccion seccion)
        {
            return seccion.Nombre_Seccion;
        }

        public Departamento ObtenerDepartamento(Seccion seccion)
        {
            return seccion.Departamento;
        }

        public List<Oficina> ObtenerOficinas(Seccion seccion)
        {
            return seccion.Oficinas.ToList();
        }

        public void AgregarOficina(Seccion seccion, Oficina oficina)
        {
            if (!seccion.Oficinas.Contains(oficina))
            {
                seccion.Oficinas.Add(oficina);
            }
        }

        public void EliminarOficina(Seccion seccion, Oficina oficina)
        {
            if (seccion.Oficinas.Contains(oficina))
            {
                seccion.Oficinas.Remove(oficina);
            }
        }

        public string ObtenerEstructuraCompleta(Seccion seccion)
        {
            return $"{seccion.Departamento.Nombre_Departamento} > {seccion.Nombre_Seccion}";
        }
    }
}
