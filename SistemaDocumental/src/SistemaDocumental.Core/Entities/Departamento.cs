using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Departamento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Departamento { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public int ID_Direccion { get; set; } // Relacionado con la tabla Direccion

        [ForeignKey("ID_Direccion")]
        public virtual Direccion Direccion { get; set; }
    }
}
