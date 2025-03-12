using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class VersionHistorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Registro { get; set; }

        [Required]
        public int ID_Documento { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int Usuario_Modificador { get; set; }

        [Required]
        public int ID_Accion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public byte[] Contenido { get; set; } // Almacena la versión del documento si es necesario

        [Required]
        [MaxLength(256)]
        public string Hash_Integridad { get; set; } // Para verificar la integridad del contenido
    }
}
