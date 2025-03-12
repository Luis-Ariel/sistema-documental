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
    }
}
