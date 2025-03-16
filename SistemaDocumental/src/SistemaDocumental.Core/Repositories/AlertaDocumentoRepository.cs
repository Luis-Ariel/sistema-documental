using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class AlertaDocumentoRepository : IAlertaDocumentoRepository
    {
        private readonly List<AlertaDocumento> _alertas = new List<AlertaDocumento>();

        public AlertaDocumento? ObtenerPorID(int id)
        {
            return _alertas.FirstOrDefault(a => a.ID_Alerta == id);
        }

        public List<AlertaDocumento> ObtenerPorDocumento(int idDocumento)
        {
            return _alertas.Where(a => a.ID_Documento == idDocumento).ToList();
        }

        public List<AlertaDocumento> ObtenerActivas()
        {
            return _alertas.Where(a => a.Activa).ToList();
        }

        public void Agregar(AlertaDocumento alerta)
        {
            _alertas.Add(alerta);
        }

        public void Actualizar(AlertaDocumento alerta)
        {
            var index = _alertas.FindIndex(a => a.ID_Alerta == alerta.ID_Alerta);
            if (index != -1)
            {
                _alertas[index] = alerta;
            }
        }

        public void Desactivar(int idAlerta)
        {
            var alerta = ObtenerPorID(idAlerta);
            if (alerta != null)
            {
                alerta.Activa = false;
                Actualizar(alerta);
            }
        }
    }
}
