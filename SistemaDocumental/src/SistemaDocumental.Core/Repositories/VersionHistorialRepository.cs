using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class VersionHistorialRepository : IVersionHistorialRepository
    {
        private readonly List<VersionHistorial> _versiones = new List<VersionHistorial>();

        public VersionHistorial? ObtenerPorID(int id)
        {
            return _versiones.FirstOrDefault(v => v.ID_Registro == id);
        }

        public List<VersionHistorial> ObtenerHistorialPorDocumento(int idDocumento)
        {
            return _versiones.Where(v => v.ID_Documento == idDocumento).ToList();
        }

        public List<VersionHistorial> ObtenerHistorialPorUsuario(int idUsuario)
        {
            return _versiones.Where(v => v.ID_UsuarioModificador == idUsuario).ToList();
        }

        public void CrearNuevaVersion(VersionHistorial version)
        {
            _versiones.Add(version);
        }

        public bool ValidarIntegridad(string hash)
        {
            return _versiones.Any(v => v.Hash_Integridad == hash);
        }
    }
}
