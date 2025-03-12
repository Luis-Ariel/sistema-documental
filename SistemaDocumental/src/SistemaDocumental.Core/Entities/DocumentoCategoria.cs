using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class DocumentoCategoria
    {
        [Required]
        public int ID_Documento { get; set; } // Relacionado con la tabla Documento

        [Required]
        public int ID_Categoria { get; set; } // Relacionado con la tabla Categoria

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; }

        [ForeignKey("ID_Categoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
