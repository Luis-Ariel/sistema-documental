using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Entities
{
    public class AlertaDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Alerta { get; set; }

        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; } = null!; // Inicialización para evitar warning

        [Required]
        public TipoAlerta Tipo { get; set; } // Tipo de alerta (Modificación, Eliminación, Vencimiento)

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;

        public bool Activa { get; set; } = true; // Indica si la alerta sigue vigente

        // Relación 1-N: Una alerta puede tener múltiples destinatarios
        public virtual ICollection<AlertaDestinatario> Destinatarios { get; set; } = new List<AlertaDestinatario>();

        // Relación 1-N: Una alerta puede generar múltiples notificaciones
        public virtual ICollection<NotificacionEvento> Notificaciones { get; set; } = new List<NotificacionEvento>();
    }
}
