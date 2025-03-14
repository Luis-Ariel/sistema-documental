using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class CategoriaTipoDocumento
    {
        // Clave foránea: Categoría
        [Required]
        public int ID_Categoria { get; set; }

        [ForeignKey("ID_Categoria")]
        public required Categoria Categoria { get; set; }

        // Clave foránea: Tipo de Documento
        [Required]
        public int ID_TipoDocumento { get; set; }

        [ForeignKey("ID_TipoDocumento")]
        public required TipoDocumento TipoDocumento { get; set; }

        // Constructor obligatorio para asegurar que las propiedades no sean nulas
        public CategoriaTipoDocumento(int idCategoria, Categoria categoria, int idTipoDocumento, TipoDocumento tipoDocumento)
        {
            ID_Categoria = idCategoria;
            Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria));
            ID_TipoDocumento = idTipoDocumento;
            TipoDocumento = tipoDocumento ?? throw new ArgumentNullException(nameof(tipoDocumento));
        }

        // Constructor vacío para Entity Framework
        private CategoriaTipoDocumento() { }
    }
}
