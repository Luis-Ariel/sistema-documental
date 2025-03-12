using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class DocumentacionSistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Documento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } // Título de la documentación

        [Required]
        public string Contenido { get; set; } // Texto o enlace a la documentación en línea

        [Required]
        public TipoDocumentacion Categoria { get; set; } // Tipo de documentación

        [Required]
        public DateTime Fecha_Actualizacion { get; set; } = DateTime.Now; // Fecha de la última actualización
    }

    public enum TipoDocumentacion
    {
        GuiaUsuario,
        FAQ,
        ManualTecnico
    }
}
