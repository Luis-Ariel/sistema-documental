using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class FormatoPermitido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Formato { get; set; }

        [Required]
        [MaxLength(10)]
        public string Extension { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        [MaxLength(200)]
        public string Descripcion { get; set; } = string.Empty; // Evita valores NULL sin afectar la base de datos

        // Relación 1-N: Un formato puede estar en múltiples tipos de documentos
        public virtual ICollection<TipoDocumento> TiposDeDocumentos { get; set; } = new List<TipoDocumento>();

        // Constructor vacío necesario para Entity Framework
        public FormatoPermitido() { }

        // Constructor con parámetros para inicializar los valores requeridos
        public FormatoPermitido(string extension, string descripcion = "")
        {
            Extension = extension;
            Descripcion = descripcion;
        }
    }
}
