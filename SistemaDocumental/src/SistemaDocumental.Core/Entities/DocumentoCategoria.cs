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
        public virtual Documento Documento { get; set; } = null!; // Inicialización para evitar warnings

        // Clave foránea: Categoría
        [Required]
        public int ID_Categoria { get; set; }

        [ForeignKey("ID_Categoria")]
        public virtual Categoria Categoria { get; set; } = null!; // Inicialización para evitar warnings

        // Constructor obligatorio para asegurar inicialización
        public DocumentoCategoria(int idDocumento, Documento documento, int idCategoria, Categoria categoria)
        {
            ID_Documento = idDocumento;
            Documento = documento;
            ID_Categoria = idCategoria;
            Categoria = categoria;
        }

        // Constructor vacío requerido por Entity Framework
        private DocumentoCategoria() { }
    }
}
