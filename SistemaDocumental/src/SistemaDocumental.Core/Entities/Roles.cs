using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Grupo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Grupo { get; set; } // Nombre del rol o grupo

        [Required]
        public int Nivel { get; set; } // Nivel jerárquico del rol

        public string Descripcion { get; set; } // Descripción opcional del grupo

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now; // Fecha de creación del rol

        public int? ID_GrupoPadre { get; set; } // Grupo superior (para jerarquía)

        [ForeignKey("ID_GrupoPadre")]
        public virtual Roles GrupoPadre { get; set; }
    }
}
