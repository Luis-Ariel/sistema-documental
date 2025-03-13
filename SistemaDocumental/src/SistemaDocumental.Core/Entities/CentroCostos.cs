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
        public string Descripcion { get; set; } // Nombre o detalle del centro de costos

        [Required]
        [MaxLength(100)]
        public string Jefatura { get; set; } // Nombre del responsable o líder del centro de costos

        // Relación 1-N: Un centro de costos puede estar asignado a múltiples oficinas
        public virtual ICollection<Oficina> Oficinas { get; set; } = new List<Oficina>();

        // Relación 1-N: Un centro de costos puede estar asignado a múltiples usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
