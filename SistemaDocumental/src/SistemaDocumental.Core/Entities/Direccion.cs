using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Direccion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Direccion { get; set; }

        public string Descripcion { get; set; } 

        // Relación 1-N: Una dirección puede contener múltiples departamentos
        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
