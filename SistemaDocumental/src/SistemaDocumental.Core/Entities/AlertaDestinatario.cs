using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class AlertaDestinatario
    {
        // Clave foránea: Alerta asociada
        [Required]
        public int ID_Alerta { get; set; }

        [ForeignKey("ID_Alerta")]
        public virtual AlertaDocumento Alerta { get; set; }

        // Clave foránea: Destinatario (Usuario o Grupo)
        public int? ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; }

        public int? ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Roles Grupo { get; set; }
    }
}
