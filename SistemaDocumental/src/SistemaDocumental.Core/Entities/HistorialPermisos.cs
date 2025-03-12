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

        [Required]
        public int ID_Usuario { get; set; } // Usuario que realizó el cambio

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha del cambio

        [Required]
        public int ID_Permiso { get; set; } // Permiso afectado

        [Required]
        public TipoCambioPermiso Tipo_Cambio { get; set; } // Tipo de cambio realizado

        public int? ID_Grupo { get; set; } // Grupo afectado (puede ser nulo)

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
