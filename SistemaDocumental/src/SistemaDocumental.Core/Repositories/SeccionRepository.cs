using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class SeccionRepository : ISeccionRepository
    {
        private readonly List<Seccion> _secciones = new List<Seccion>();

        public Seccion? ObtenerPorID(int id)
        {
            return _secciones.FirstOrDefault(s => s.ID_Seccion == id);
        }

        public List<Seccion> ObtenerTodas()
        {
            return _secciones;
        }

        public void Agregar(Seccion seccion)
        {
            _secciones.Add(seccion);
        }

        public void Eliminar(Seccion seccion)
        {
            _secciones.Remove(seccion);
        }
    }
}
