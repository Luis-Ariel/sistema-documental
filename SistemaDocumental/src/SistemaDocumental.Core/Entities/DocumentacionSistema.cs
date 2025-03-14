using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Entities
{
    public class DocumentacionSistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Documento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        [Required]
        public string Contenido { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        [Required]
        public TipoDocumentacion Categoria { get; set; } // Tipo de documentación

        [Required]
        public DateTime Fecha_Actualizacion { get; set; } = DateTime.Now; // Fecha de la última actualización

        // Constructor vacío necesario para Entity Framework
        public DocumentacionSistema() { }

        // Constructor con parámetros para inicializar los valores requeridos
        public DocumentacionSistema(string titulo, string contenido, TipoDocumentacion categoria)
        {
            Titulo = titulo;
            Contenido = contenido;
            Categoria = categoria;
            Fecha_Actualizacion = DateTime.Now;
        }
    }
}
