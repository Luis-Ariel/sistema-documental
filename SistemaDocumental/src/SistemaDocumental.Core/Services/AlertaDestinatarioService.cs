using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class AlertaDestinatarioService
    {
        private readonly IAlertaDestinatarioRepository _destinatarioRepository;

        public AlertaDestinatarioService(IAlertaDestinatarioRepository destinatarioRepository)
        {
            _destinatarioRepository = destinatarioRepository;
        }

        public int ObtenerID(AlertaDestinatario destinatario)
        {
            return destinatario.ID_Alerta;
        }

        public AlertaDocumento ObtenerAlerta(AlertaDestinatario destinatario)
        {
            return destinatario.Alerta;
        }

        public Usuario? ObtenerUsuario(AlertaDestinatario destinatario)
        {
            return destinatario.Usuario;
        }

        public Roles? ObtenerGrupo(AlertaDestinatario destinatario)
        {
            return destinatario.Grupo;
        }

        public void AsignarAUsuario(AlertaDocumento alerta, Usuario usuario)
        {
            var destinatario = new AlertaDestinatario(alerta.ID_Alerta, alerta)
            {
                Usuario = usuario
            };
            _destinatarioRepository.Agregar(destinatario);
        }

        public void AsignarAGrupo(AlertaDocumento alerta, Roles grupo)
        {
            var destinatario = new AlertaDestinatario(alerta.ID_Alerta, alerta)
            {
                Grupo = grupo
            };
            _destinatarioRepository.Agregar(destinatario);
        }

        public List<Usuario> ObtenerUsuariosPorAlerta(int idAlerta)
        {
            var destinatarios = _destinatarioRepository.ObtenerPorAlerta(idAlerta);
            return destinatarios.Where(d => d.Usuario != null).Select(d => d.Usuario!).ToList();
        }

        public List<Roles> ObtenerGruposPorAlerta(int idAlerta)
        {
            var destinatarios = _destinatarioRepository.ObtenerPorAlerta(idAlerta);
            return destinatarios.Where(d => d.Grupo != null).Select(d => d.Grupo!).ToList();
        }

        public void EliminarDestinatario(int idDestinatario)
        {
            _destinatarioRepository.Eliminar(idDestinatario);
        }
    }
}
