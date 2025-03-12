using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class NotificacionEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Notificacion { get; set; }

        public int? ID_Accion { get; set; } // Puede ser nulo si la notificación es manual

        public int? ID_Alerta_Documento { get; set; } // Puede estar ligada a una alerta

        [Required]
        public int ID_Usuario { get; set; } // Usuario destinatario de la notificación

        [Required]
        public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;

        public DateTime? Fecha_Programada { get; set; } // Si es una notificación futura

        public DateTime? Fecha_Envio { get; set; } // Fecha en que se envió

        [Required]
        public string Mensaje { get; set; } // Contenido de la notificación
    }

    public enum EstadoNotificacion
    {
        Pendiente,
        Enviado,
        Cancelado
    }
}
