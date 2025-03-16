using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Repositories
{
    public class AlertaDestinatarioRepository : IAlertaDestinatarioRepository
    {
        private readonly List<AlertaDestinatario> _destinatarios = new List<AlertaDestinatario>();

        public AlertaDestinatario? ObtenerPorID(int id)
        {
            return _destinatarios.FirstOrDefault(d => d.ID_Alerta == id);
        }

        public List<AlertaDestinatario> ObtenerPorAlerta(int idAlerta)
        {
            return _destinatarios.Where(d => d.ID_Alerta == idAlerta).ToList();
        }

        public List<AlertaDestinatario> ObtenerPorUsuario(int idUsuario)
        {
            return _destinatarios.Where(d => d.ID_Usuario == idUsuario).ToList();
        }

        public List<AlertaDestinatario> ObtenerPorGrupo(int idGrupo)
        {
            return _destinatarios.Where(d => d.ID_Grupo == idGrupo).ToList();
        }

        public void Agregar(AlertaDestinatario destinatario)
        {
            _destinatarios.Add(destinatario);
        }

        public void Eliminar(int idDestinatario)
        {
            var destinatario = ObtenerPorID(idDestinatario);
            if (destinatario != null)
            {
                _destinatarios.Remove(destinatario);
            }
        }
    }
}
