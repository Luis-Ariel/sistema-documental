using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class SesionUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Sesion { get; set; }

        [Required]
        public int ID_Usuario { get; set; } // Relacionado con la tabla Usuario

        [Required]
        public DateTime Fecha_Inicio { get; set; } = DateTime.Now; // Inicio de la sesión

        public DateTime? Fecha_Expiracion { get; set; } // Cuándo expira la sesión

        [Required]
        public EstadoSesion Estado { get; set; } = EstadoSesion.Activa; // Estado de la sesión

        [Required]
        [MaxLength(45)]
        public string IP { get; set; } // Dirección IP del usuario

        [Required]
        public bool Doble_Factor_Completado { get; set; } = false; // Indica si el 2FA fue completado

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; }
    }

    public enum EstadoSesion
    {
        Activa,
        Expirada,
        Cerrada
    }
}
