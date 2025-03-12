using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class CategoriaTipoDocumento
    {
        [Required]
        public int ID_Categoria { get; set; } // Relacionado con la tabla Categoria

        [Required]
        public int ID_Tipo_Documento { get; set; } // Relacionado con la tabla Tipo_Documento

        [ForeignKey("ID_Categoria")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("ID_Tipo_Documento")]
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
