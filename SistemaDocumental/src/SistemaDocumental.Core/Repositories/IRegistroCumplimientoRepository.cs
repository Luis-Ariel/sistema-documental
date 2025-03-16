using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface IRegistroCumplimientoRepository
    {
        RegistroCumplimiento? ObtenerPorID(int id);
        List<RegistroCumplimiento> ObtenerTodos();
        List<RegistroCumplimiento> ObtenerPorDocumento(int idDocumento);
        List<RegistroCumplimiento> ObtenerPorUsuario(int idUsuario);
        List<RegistroCumplimiento> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin);
        void RegistrarRevision(RegistroCumplimiento registro);
    }
}
