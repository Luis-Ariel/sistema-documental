using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class RolPermiso
    {
        [Required]
        public DateTime Fecha_Asignacion { get; set; } = DateTime.Now; // Fecha en que se otorgó el permiso

        // Clave foránea: Rol
        [Required]
        public int ID_Rol { get; set; }

        [ForeignKey("ID_Rol")]
        public virtual Roles Rol { get; set; } = null!; // Inicialización para evitar warning

        // Clave foránea: Permiso
        [Required]
        public int ID_Permiso { get; set; }

        [ForeignKey("ID_Permiso")]
        public virtual Permiso Permiso { get; set; } = null!; // Inicialización para evitar warning
    }
}
