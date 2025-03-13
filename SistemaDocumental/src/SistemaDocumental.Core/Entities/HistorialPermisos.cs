using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class HistorialPermisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Historial { get; set; }

        // Clave foránea: Usuario que realizó el cambio de permisos
        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; }

        [Required]
        public int ID_Permiso { get; set; }

        [ForeignKey("ID_Permiso")]
        public virtual Permiso Permiso { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha del cambio

        [Required]
        public TipoCambioPermiso Tipo_Cambio { get; set; } // Tipo de cambio realizado

        // Clave foránea: Grupo (Rol) que recibió la modificación de permisos (opcional)
        public int? ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Rol Grupo { get; set; }

        [Required]
        public NivelAcceso Nivel_Acceso { get; set; } // Nivel de acceso del permiso

        public string Descripcion { get; set; } // Descripción adicional del cambio
    }

    public enum TipoCambioPermiso
    {
        Asignado,
        Modificado,
        Eliminado
    }

    public enum NivelAcceso
    {
        Lectura,
        Escritura,
        Edicion,
        Eliminacion
    }
}
