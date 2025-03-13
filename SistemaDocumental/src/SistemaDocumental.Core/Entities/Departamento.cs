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

        public int ID_Direccion { get; set; }

        [ForeignKey("ID_Direccion")]
        public virtual Direccion Direccion { get; set; }

        // Relación 1-N: Un departamento puede contener múltiples secciones
        public virtual ICollection<Seccion> Secciones { get; set; } = new List<Seccion>();
    }
}
