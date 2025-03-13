using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 //toca solucionar que solo la accion de modificar genere version_historial
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
        public virtual Usuario Usuario { get; set; }

        // Clave foránea: Documento sobre el que se realizó la acción
        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; }

        public string Detalles { get; set; }

        public bool Notificar { get; set; } = false;

        [MaxLength(255)]
        public string Notificacion_Detalle { get; set; }

        // Clave foránea opcional: Acción padre (si aplica)
        public int? ID_AccionPadre { get; set; }

        [ForeignKey("ID_AccionPadre")]
        public virtual Accion AccionPadre { get; set; }

        // Relación 1-N: Una acción puede generar múltiples versiones de historial
        public virtual ICollection<VersionHistorial> VersionesHistorial { get; set; } = new List<VersionHistorial>();

        // Relación 1-N: Una acción puede generar múltiples notificaciones
        public virtual ICollection<NotificacionEvento> Notificaciones { get; set; } = new List<NotificacionEvento>();

        // Relación 1-N: Una acción padre puede tener varias acciones hijas
        public virtual ICollection<Accion> AccionesRelacionadas { get; set; } = new List<Accion>();
    }

    public enum TipoAccion
    {
        Subida,
        Descarga,
        Compartir,
        Eliminar,
        Imprimir,
        Modificacion, // Solo esta acción generará un VersionHistorial
        Validacion
    }
}
