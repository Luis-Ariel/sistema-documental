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
        public string Nombre_Oficina { get; set; }

        [Required]
        public int ID_Seccion { get; set; } // Relacionado con la tabla Seccion

        public int? ID_Centro_Costos { get; set; } // Centro de costos al que está asociada la oficina

        public string Descripcion { get; set; }

        [ForeignKey("ID_Seccion")]
        public virtual Seccion Seccion { get; set; }

        [ForeignKey("ID_Centro_Costos")]
        public virtual CentroCostos CentroCostos { get; set; }
    }
}
