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
        public string Descripcion { get; set; } = string.Empty; // Inicialización para evitar warning

        [Required]
        public int Responsable { get; set; } // Usuario responsable de la auditoría

        [Required]
        public bool Cumple { get; set; } = false; // Indica si cumple con la normativa

        [Required]
        public int ID_UsuarioResponsable { get; set; }

        [ForeignKey("ID_UsuarioResponsable")]
        public virtual Usuario UsuarioResponsable { get; set; } = null!; // Inicialización para evitar warning

        // Clave foránea: Documento al que pertenece el registro de cumplimiento
        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; } = null!; // Inicialización para evitar warning
    }
}
