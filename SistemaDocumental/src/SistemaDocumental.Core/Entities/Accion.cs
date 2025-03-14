using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

// Toca solucionar que solo la acción de modificar genere VersionHistorial
namespace SistemaDocumental.Core.Entities
{
    public class Accion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Accion { get; set; }

        [Required]
        public TipoAccion Tipo { get; set; }

        [Required]
        public DateTime Fecha_Accion { get; set; } = DateTime.Now;

        // Clave foránea: Usuario que realizó la acción
        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; } = null!; // Inicialización para evitar warning

        // Clave foránea: Documento sobre el que se realizó la acción
        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; } = null!;

        public string Detalles { get; set; } = string.Empty;

        public bool Notificar { get; set; } = false;

        [MaxLength(255)]
        public string Notificacion_Detalle { get; set; } = string.Empty;

        // Clave foránea opcional: Acción padre (si aplica)
        public int? ID_AccionPadre { get; set; }

        [ForeignKey("ID_AccionPadre")]
        public virtual Accion? AccionPadre { get; set; } // Se permite null porque es opcional

        // Relación 1-N: Una acción puede generar múltiples versiones de historial
        public virtual ICollection<VersionHistorial> VersionesHistorial { get; set; } = new List<VersionHistorial>();

        // Relación 1-N: Una acción puede generar múltiples notificaciones
        public virtual ICollection<NotificacionEvento> Notificaciones { get; set; } = new List<NotificacionEvento>();

        // Relación 1-N: Una acción padre puede tener varias acciones hijas
        public virtual ICollection<Accion> AccionesRelacionadas { get; set; } = new List<Accion>();
    }
}
