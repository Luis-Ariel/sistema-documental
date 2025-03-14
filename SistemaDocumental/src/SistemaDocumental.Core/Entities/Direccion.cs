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
        public string Nombre_Direccion { get; set; } = string.Empty; // Evita el warning sin permitir valores NULL

        public string Descripcion { get; set; } = string.Empty; // Evita el warning sin permitir valores NULL

        // Relación 1-N: Una dirección puede contener múltiples departamentos
        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

        // Constructor vacío requerido por Entity Framework
        public Direccion() { }

        // Constructor con parámetros para asegurar inicialización correcta
        public Direccion(string nombreDireccion, string descripcion)
        {
            Nombre_Direccion = nombreDireccion;
            Descripcion = descripcion;
        }
    }
}
