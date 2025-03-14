using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class CentroCostos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Centro_Costos { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        [Required]
        [MaxLength(100)]
        public string Jefatura { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        // Relación 1-N: Un centro de costos puede estar asignado a múltiples oficinas
        public virtual ICollection<Oficina> Oficinas { get; set; } = new List<Oficina>();

        // Relación 1-N: Un centro de costos puede estar asignado a múltiples usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        // Constructor vacío necesario para Entity Framework
        public CentroCostos() { }

        // Constructor con parámetros para inicializar los valores requeridos
        public CentroCostos(string descripcion, string jefatura)
        {
            Descripcion = descripcion;
            Jefatura = jefatura;
        }
    }
}
