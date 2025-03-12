using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Contraseña_Hash { get; set; } // Contraseña almacenada de forma segura

        [Required]
        public int ID_Grupo { get; set; } // Relacionado con la tabla Roles

        public int? ID_Oficina { get; set; } // Oficina a la que pertenece el usuario

        public int? ID_Centro_Costos { get; set; } // Centro de costos al que está asociado

        [Required]
        public bool Activo { get; set; } = true; // Estado del usuario (activo/inactivo)

        [ForeignKey("ID_Grupo")]
        public virtual Roles Grupo { get; set; }

        [ForeignKey("ID_Oficina")]
        public virtual Oficina Oficina { get; set; }

        [ForeignKey("ID_Centro_Costos")]
        public virtual CentroCostos CentroCostos { get; set; }
    }
}
