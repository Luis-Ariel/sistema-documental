using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class RegistroCumplimientoService
    {
        private readonly IRegistroCumplimientoRepository _registroCumplimientoRepository;

        public RegistroCumplimientoService(IRegistroCumplimientoRepository registroCumplimientoRepository)
        {
            _registroCumplimientoRepository = registroCumplimientoRepository;
        }

        public int ObtenerID(RegistroCumplimiento registro)
        {
            return registro.ID_Registro;
        }

        public DateTime ObtenerFecha(RegistroCumplimiento registro)
        {
            return registro.Fecha;
        }

        public string ObtenerDescripcion(RegistroCumplimiento registro)
        {
            return registro.Descripcion;
        }

        public bool CumpleNormativa(RegistroCumplimiento registro)
        {
            return registro.Cumple;
        }

        public Usuario ObtenerUsuarioResponsable(RegistroCumplimiento registro)
        {
            return registro.UsuarioResponsable;
        }

        public Documento ObtenerDocumento(RegistroCumplimiento registro)
        {
            return registro.Documento;
        }

        public void RegistrarRevision(RegistroCumplimiento registro)
        {
            _registroCumplimientoRepository.RegistrarRevision(registro);
        }

        public List<RegistroCumplimiento> ObtenerRevisionesPorDocumento(int idDocumento)
        {
            return _registroCumplimientoRepository.ObtenerPorDocumento(idDocumento);
        }

        public List<RegistroCumplimiento> ObtenerRevisionesPorUsuario(int idUsuario)
        {
            return _registroCumplimientoRepository.ObtenerPorUsuario(idUsuario);
        }

        public List<RegistroCumplimiento> ObtenerRevisionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _registroCumplimientoRepository.ObtenerPorFecha(fechaInicio, fechaFin);
        }
    }
}
