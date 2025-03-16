using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IAccionRepository
    {
        Accion? ObtenerPorID(int id);
        List<Accion> ObtenerTodas();
        List<Accion> BuscarPorUsuario(Usuario usuario);
        List<Accion> BuscarPorDocumento(Documento documento);
        List<Accion> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin);
        List<Accion> BuscarPorTipo(TipoAccion tipo);
        Accion? ObtenerOperacionMasiva(int idAccion);
        void AgregarAccion(Accion accion);
        void ActualizarAccion(Accion accion);
        void EliminarAccion(int id);
    }
}
