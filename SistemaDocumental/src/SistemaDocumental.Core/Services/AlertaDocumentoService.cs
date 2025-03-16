using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class AlertaDocumentoService
    {
        private readonly IAlertaDocumentoRepository _alertaRepository;
        private readonly INotificacionEventoRepository _notificacionRepository;

        public AlertaDocumentoService(IAlertaDocumentoRepository alertaRepository, INotificacionEventoRepository notificacionRepository)
        {
            _alertaRepository = alertaRepository;
            _notificacionRepository = notificacionRepository;
        }

        public int ObtenerID(AlertaDocumento alerta)
        {
            return alerta.ID_Alerta;
        }

        public Documento ObtenerDocumento(AlertaDocumento alerta)
        {
            return alerta.Documento;
        }

        public string ObtenerTipo(AlertaDocumento alerta)
        {
            return alerta.Tipo.ToString();
        }

        public DateTime ObtenerFechaCreacion(AlertaDocumento alerta)
        {
            return alerta.Fecha_Creacion;
        }

        public bool EstaActiva(AlertaDocumento alerta)
        {
            return alerta.Activa;
        }

        public void Activar(AlertaDocumento alerta)
        {
            alerta.Activa = true;
            _alertaRepository.Actualizar(alerta);
        }

        public void Desactivar(AlertaDocumento alerta)
        {
            alerta.Activa = false;
            _alertaRepository.Actualizar(alerta);
        }

        public void AsignarDestinatario(AlertaDocumento alerta, Usuario usuario)
        {
            alerta.Destinatarios.Add(new AlertaDestinatario(alerta.ID_Alerta, alerta) { Usuario = usuario });
            _alertaRepository.Actualizar(alerta);
        }

        public List<Usuario> ObtenerDestinatarios(AlertaDocumento alerta)
        {
            return alerta.Destinatarios.Where(d => d.Usuario != null).Select(d => d.Usuario!).ToList();
        }

        public NotificacionEvento GenerarNotificacion(AlertaDocumento alerta)
        {
            if (!alerta.Destinatarios.Any())
                throw new InvalidOperationException("No se pueden generar notificaciones sin destinatarios.");

            var usuarioDestino = alerta.Destinatarios.First().Usuario;
            if (usuarioDestino == null)
                throw new InvalidOperationException("El destinatario de la alerta no está definido.");

            var notificacion = new NotificacionEvento(usuarioDestino.ID_Usuario, "Nueva alerta de documento", EstadoNotificacion.Pendiente)
            {
                ID_Alerta_Documento = alerta.ID_Alerta
            };

            _notificacionRepository.Agregar(notificacion);
            return notificacion;
        }
    }
}
