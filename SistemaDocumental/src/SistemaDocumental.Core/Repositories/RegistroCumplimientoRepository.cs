using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class RegistroCumplimientoRepository : IRegistroCumplimientoRepository
    {
        private readonly List<RegistroCumplimiento> _registros = new List<RegistroCumplimiento>();

        public RegistroCumplimiento? ObtenerPorID(int id)
        {
            return _registros.FirstOrDefault(r => r.ID_Registro == id);
        }

        public List<RegistroCumplimiento> ObtenerTodos()
        {
            return _registros;
        }

        public List<RegistroCumplimiento> ObtenerPorDocumento(int idDocumento)
        {
            return _registros.Where(r => r.ID_Documento == idDocumento).ToList();
        }

        public List<RegistroCumplimiento> ObtenerPorUsuario(int idUsuario)
        {
            return _registros.Where(r => r.ID_UsuarioResponsable == idUsuario).ToList();
        }

        public List<RegistroCumplimiento> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _registros.Where(r => r.Fecha >= fechaInicio && r.Fecha <= fechaFin).ToList();
        }

        public void RegistrarRevision(RegistroCumplimiento registro)
        {
            _registros.Add(registro);
        }
    }
}
