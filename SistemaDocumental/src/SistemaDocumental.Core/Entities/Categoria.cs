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
        public string Nombre_Categoria { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        public string Descripcion { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        // Relación 1-N: Una categoría puede estar en múltiples DocumentoCategoria
        public virtual ICollection<DocumentoCategoria> DocumentosCategoria { get; set; } = new List<DocumentoCategoria>();

        // Relación 1-N: Una categoría puede estar en múltiples CategoriaTipoDocumento
        public virtual ICollection<CategoriaTipoDocumento> TiposDeDocumentos { get; set; } = new List<CategoriaTipoDocumento>();

        // Constructor vacío necesario para Entity Framework
        public Categoria() { }

        // Constructor con parámetros para inicializar los valores requeridos
        public Categoria(string nombre, string descripcion)
        {
            Nombre_Categoria = nombre;
            Descripcion = descripcion;
        }
    }
}
