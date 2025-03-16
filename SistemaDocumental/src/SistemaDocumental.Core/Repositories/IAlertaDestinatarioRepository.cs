using System.Collections.Generic;
using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface IAlertaDestinatarioRepository
    {
        AlertaDestinatario? ObtenerPorID(int id);
        List<AlertaDestinatario> ObtenerPorAlerta(int idAlerta);
        List<AlertaDestinatario> ObtenerPorUsuario(int idUsuario);
        List<AlertaDestinatario> ObtenerPorGrupo(int idGrupo);
        void Agregar(AlertaDestinatario destinatario);
        void Eliminar(int idDestinatario);
    }
}
