using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Oficina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Oficina { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Oficina { get; set; } = string.Empty; // Inicialización para evitar warning

        public int ID_Seccion { get; set; }

        [ForeignKey("ID_Seccion")]
        public virtual Seccion Seccion { get; set; } = null!; // Inicialización para evitar warning

        public int ID_Centro_Costos { get; set; }

        [ForeignKey("ID_Centro_Costos")]
        public virtual CentroCostos CentroCostos { get; set; } = null!;

        public string Descripcion { get; set; } = string.Empty;

        // Relación 1-N: Una oficina puede tener múltiples usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
