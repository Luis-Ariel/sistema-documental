using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Categoria { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Categoria { get; set; } // Nombre de la categoría

        public string Descripcion { get; set; } // Información adicional sobre la categoría

        // Relación 1-N: Una categoría puede estar en múltiples DocumentoCategoria
        public virtual ICollection<DocumentoCategoria> DocumentosCategoria { get; set; } = new List<DocumentoCategoria>();

        // Relación 1-N: Una categoría puede estar en múltiples CategoriaTipoDocumento
        public virtual ICollection<CategoriaTipoDocumento> TiposDeDocumentos { get; set; } = new List<CategoriaTipoDocumento>();
    }
}
