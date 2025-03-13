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

        // Clave foránea opcional: Alerta que originó la notificación
        public int? ID_Alerta_Documento { get; set; }

        [ForeignKey("ID_Alerta_Documento")]
        public virtual AlertaDocumento AlertaDocumento { get; set; }

        // Clave foránea opcional: Acción que originó la notificación
        public int? ID_Accion { get; set; }

        [ForeignKey("ID_Accion")]
        public virtual Accion Accion { get; set; }

        // Destinatario de la notificación (Usuario o Grupo)
        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; }

        public int? ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Roles Grupo { get; set; }

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
