using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Tipo_Documento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre_Tipo { get; set; } = string.Empty; // Inicialización para evitar warning

        public string Descripcion { get; set; } = string.Empty; // Inicialización para evitar warning

        // Clave foránea: Formato permitido
        [Required]
        public int ID_Formato { get; set; }

        [ForeignKey("ID_Formato")]
        public virtual FormatoPermitido FormatoPermitido { get; set; } = null!; // Inicialización para evitar warning

        // Relación 1-N: Un tipo de documento puede estar en múltiples CategoriaTipoDocumento
        public virtual ICollection<CategoriaTipoDocumento> CategoriasTipoDocumento { get; set; } = new List<CategoriaTipoDocumento>();

        // Relación 1-N: Un tipo de documento puede estar asociado a múltiples documentos
        public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
    }
}
