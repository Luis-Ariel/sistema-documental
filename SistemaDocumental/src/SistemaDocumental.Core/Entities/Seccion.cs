using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Seccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Seccion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Seccion { get; set; }

        [Required]
        public int ID_Departamento { get; set; } // Relacionado con la tabla Departamento

        public string Descripcion { get; set; }

        [ForeignKey("ID_Departamento")]
        public virtual Departamento Departamento { get; set; }
    }
}
