using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface IAlertaDocumentoRepository
    {
        AlertaDocumento? ObtenerPorID(int id);
        List<AlertaDocumento> ObtenerPorDocumento(int idDocumento);
        List<AlertaDocumento> ObtenerActivas();
        void Agregar(AlertaDocumento alerta);
        void Actualizar(AlertaDocumento alerta);
        void Desactivar(int idAlerta);
    }
}
