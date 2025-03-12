using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class RolPermiso
    {
        [Required]
        public int ID_Rol { get; set; } // Relacionado con la tabla Roles

        [Required]
        public int ID_Permiso { get; set; } // Relacionado con la tabla Permiso

        [Required]
        public DateTime Fecha_Asignacion { get; set; } = DateTime.Now; // Fecha en que se otorgó el permiso

        [ForeignKey("ID_Rol")]
        public virtual Roles Rol { get; set; }

        [ForeignKey("ID_Permiso")]
        public virtual Permiso Permiso { get; set; }
    }
}
