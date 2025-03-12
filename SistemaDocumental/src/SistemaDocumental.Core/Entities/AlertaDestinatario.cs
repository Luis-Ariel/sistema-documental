using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class AlertaDestinatario
    {
        [Required]
        public int ID_Alerta { get; set; } // Alerta asociada

        public int? ID_Usuario { get; set; } // Usuario destinatario (puede ser nulo si se asigna a un grupo)

        public int? ID_Grupo { get; set; } // Grupo destinatario (puede ser nulo si se asigna a un usuario)

        [Required]
        public bool Activa { get; set; } = true; // Indica si la alerta sigue vigente

        [ForeignKey("ID_Alerta")]
        public virtual AlertaDocumento Alerta { get; set; }
    }
}
