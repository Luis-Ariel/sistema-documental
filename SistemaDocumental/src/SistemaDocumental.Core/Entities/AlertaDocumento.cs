using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class AlertaDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Alerta { get; set; }

        [Required]
        public int ID_Documento { get; set; } // Documento al que está asociada la alerta

        [Required]
        public TipoAlerta Tipo { get; set; } // Tipo de alerta (Modificación, Eliminación, Vencimiento)

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;

        public bool Activa { get; set; } = true; // Indica si la alerta sigue vigente
    }

    public enum TipoAlerta
    {
        Modificacion,
        Eliminacion,
        Vencimiento
    }
}
