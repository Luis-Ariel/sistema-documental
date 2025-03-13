using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Permiso { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } // Nombre del permiso (Ej: "Editar Documentos")

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now; // Fecha en que se creó el permiso

        [Required]
        public NivelAcceso Nivel_Acceso { get; set; } // Nivel de acceso del permiso

        public string Descripcion { get; set; } // Descripción opcional del permiso

        // Relación 1-N: Un permiso puede estar asociado a múltiples roles a través de RolPermiso
        public virtual ICollection<RolPermiso> RolesAsignados { get; set; } = new List<RolPermiso>();

        // Relación 1-N: Un permiso puede haber sido modificado en múltiples registros de historial
        public virtual ICollection<HistorialPermiso> HistorialModificaciones { get; set; } = new List<HistorialPermiso>();
    }

    public enum NivelAcceso
    {
        Lectura,
        Escritura,
        Edicion,
        Eliminacion
    }
}
