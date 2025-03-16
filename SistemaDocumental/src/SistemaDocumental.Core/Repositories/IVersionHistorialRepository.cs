using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface IVersionHistorialRepository
    {
        VersionHistorial? ObtenerPorID(int id);
        List<VersionHistorial> ObtenerHistorialPorDocumento(int idDocumento);
        List<VersionHistorial> ObtenerHistorialPorUsuario(int idUsuario);
        void CrearNuevaVersion(VersionHistorial version);
        bool ValidarIntegridad(string hash);
    }
}
