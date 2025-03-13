using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class DocumentoCategoria
    {
        // Clave foránea: Documento
        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; }

        // Clave foránea: Categoría
        [Required]
        public int ID_Categoria { get; set; }

        [ForeignKey("ID_Categoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
