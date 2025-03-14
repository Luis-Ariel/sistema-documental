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
        public string Nombre_Departamento { get; set; } = string.Empty; // Evita el warning sin permitir valores NULL

        public string Descripcion { get; set; } = string.Empty; // Evita el warning sin permitir valores NULL

        public int ID_Direccion { get; set; }

        [ForeignKey("ID_Direccion")]
        public virtual Direccion Direccion { get; set; } = null!; // Se inicializa para evitar el warning

        // Relación 1-N: Un departamento puede contener múltiples secciones
        public virtual ICollection<Seccion> Secciones { get; set; } = new List<Seccion>();

        // Constructor vacío necesario para Entity Framework
        public Departamento() { }

        // Constructor con parámetros para inicializar los valores requeridos
        public Departamento(string nombreDepartamento, string descripcion, Direccion direccion)
        {
            Nombre_Departamento = nombreDepartamento;
            Descripcion = descripcion;
            Direccion = direccion;
        }
    }
}
