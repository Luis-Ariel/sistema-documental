using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class AccionService
    {
        private readonly IAccionRepository _accionRepository;

        public AccionService(IAccionRepository accionRepository)
        {
            _accionRepository = accionRepository;
        }

        public int ObtenerID(Accion accion)
        {
            return accion.ID_Accion;
        }

        public string ObtenerTipo(Accion accion)
        {
            return accion.Tipo.ToString();
        }

        public DateTime ObtenerFecha(Accion accion)
        {
            return accion.Fecha_Accion;
        }

        public Usuario ObtenerUsuario(Accion accion)
        {
            return accion.Usuario;
        }

        public Documento ObtenerDocumento(Accion accion)
        {
            return accion.Documento;
        }

        public string ObtenerDetalles(Accion accion)
        {
            return accion.Detalles;
        }

        public bool EsNotificable(Accion accion)
        {
            return accion.Notificar;
        }

        public Accion? ObtenerOperacionMasiva(int idAccion)
        {
            return _accionRepository.ObtenerOperacionMasiva(idAccion);
        }

        public List<Accion> BuscarPorUsuario(Usuario usuario)
        {
            return _accionRepository.BuscarPorUsuario(usuario);
        }

        public List<Accion> BuscarPorDocumento(Documento documento)
        {
            return _accionRepository.BuscarPorDocumento(documento);
        }

        public List<Accion> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _accionRepository.BuscarPorFecha(fechaInicio, fechaFin);
        }

        public List<Accion> BuscarPorTipo(TipoAccion tipo)
        {
            return _accionRepository.BuscarPorTipo(tipo);
        }

        public void AgregarAccion(Accion accion)
        {
            _accionRepository.AgregarAccion(accion);
        }

        public void ActualizarAccion(Accion accion)
        {
            _accionRepository.ActualizarAccion(accion);
        }

        public void EliminarAccion(int id)
        {
            _accionRepository.EliminarAccion(id);
        }
    }
}
