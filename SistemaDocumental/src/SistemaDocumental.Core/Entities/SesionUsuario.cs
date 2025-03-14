using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Entities
{
    public class SesionUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ID_Sesion { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; } = DateTime.Now;

        public DateTime? Fecha_Expiracion { get; set; } 

        [Required]
        public EstadoSesion Estado { get; set; } = EstadoSesion.Activa; 

        [Required]
        [MaxLength(45)]
        public string IP { get; set; } = string.Empty; // Inicialización

        [Required]
        public bool Doble_Factor_Completado { get; set; } = false; 

        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; } = null!; // Inicialización con `null!`
    }
}
