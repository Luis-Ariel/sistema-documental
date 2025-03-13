using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class FormatoPermitido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Formato { get; set; }

        [Required]
        [MaxLength(10)]
        public string Extension { get; set; } // Extensión del archivo (Ej: 'pdf', 'docx')

        [MaxLength(200)]
        public string Descripcion { get; set; } // Descripción opcional del formato permitido

        // Relación 1-N: Un formato puede estar en múltiples tipos de documentos
        public virtual ICollection<TipoDocumento> TiposDeDocumentos { get; set; } = new List<TipoDocumento>();
    }
}
