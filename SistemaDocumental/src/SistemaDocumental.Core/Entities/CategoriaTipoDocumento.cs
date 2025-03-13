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
        public virtual Categoria Categoria { get; set; }

        // Clave foránea: Tipo de Documento
        [Required]
        public int ID_TipoDocumento { get; set; }

        [ForeignKey("ID_TipoDocumento")]
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
