using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class RegistroCumplimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Registro { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha en que se realizó la auditoría

        [Required]
        public string Descripcion { get; set; } // Explicación de la auditoría o revisión

        [Required]
        public int Responsable { get; set; } // Usuario responsable de la auditoría

        [Required]
        public int Documento { get; set; } // Documento revisado

        [Required]
        public bool Cumple { get; set; } = false; // Indica si cumple con la normativa

        [ForeignKey("Responsable")]
        public virtual Usuario UsuarioResponsable { get; set; }

        [ForeignKey("Documento")]
        public virtual Documento DocumentoRevisado { get; set; }
    }
}
