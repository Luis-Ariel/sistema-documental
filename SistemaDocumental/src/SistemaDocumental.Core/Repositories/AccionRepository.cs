using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class AccionRepository : IAccionRepository
    {
        private readonly List<Accion> _acciones = new List<Accion>();

        public Accion? ObtenerPorID(int id)
        {
            return _acciones.FirstOrDefault(a => a.ID_Accion == id);
        }

        public List<Accion> ObtenerTodas()
        {
            return _acciones;
        }

        public List<Accion> BuscarPorUsuario(Usuario usuario)
        {
            return _acciones.Where(a => a.Usuario == usuario).ToList();
        }

        public List<Accion> BuscarPorDocumento(Documento documento)
        {
            return _acciones.Where(a => a.Documento == documento).ToList();
        }

        public List<Accion> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _acciones.Where(a => a.Fecha_Accion >= fechaInicio && a.Fecha_Accion <= fechaFin).ToList();
        }

        public List<Accion> BuscarPorTipo(TipoAccion tipo)
        {
            return _acciones.Where(a => a.Tipo == tipo).ToList();
        }

        public Accion? ObtenerOperacionMasiva(int idAccion)
        {
            return _acciones.FirstOrDefault(a => a.ID_AccionPadre == idAccion);
        }

        public void AgregarAccion(Accion accion)
        {
            _acciones.Add(accion);
        }

        public void ActualizarAccion(Accion accion)
        {
            var index = _acciones.FindIndex(a => a.ID_Accion == accion.ID_Accion);
            if (index != -1)
            {
                _acciones[index] = accion;
            }
        }

        public void EliminarAccion(int id)
        {
            var accion = ObtenerPorID(id);
            if (accion != null)
            {
                _acciones.Remove(accion);
            }
        }
    }
}
