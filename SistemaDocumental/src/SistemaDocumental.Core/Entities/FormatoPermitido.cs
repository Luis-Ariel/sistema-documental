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
    }
}
