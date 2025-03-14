using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ID_Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Contraseña_Hash { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; } = true; 

        // Clave foránea: Grupo (Rol) al que pertenece el usuario
        [Required]
        public int ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Roles Grupo { get; set; } = null!;

        public int ID_Oficina { get; set; }

        [ForeignKey("ID_Oficina")]
        public virtual Oficina Oficina { get; set; } = null!;

        public int ID_Centro_Costos { get; set; }

        [ForeignKey("ID_Centro_Costos")]
        public virtual CentroCostos CentroCostos { get; set; } = null!;

        // Inicialización de colecciones para evitar valores `null`
        public virtual ICollection<Documento> DocumentosCreados { get; set; } = new List<Documento>();
        public virtual ICollection<Documento> DocumentosModificados { get; set; } = new List<Documento>();
        public virtual ICollection<Accion> AccionesRealizadas { get; set; } = new List<Accion>();
        public virtual ICollection<NotificacionEvento> Notificaciones { get; set; } = new List<NotificacionEvento>();
        public virtual ICollection<VersionHistorial> VersionesHistorialModificadas { get; set; } = new List<VersionHistorial>();
        public virtual ICollection<HistorialPermisos> CambiosPermisos { get; set; } = new List<HistorialPermisos>();
        public virtual ICollection<AlertaDestinatario> AlertasRecibidas { get; set; } = new List<AlertaDestinatario>();
        public virtual ICollection<SesionUsuario> Sesiones { get; set; } = new List<SesionUsuario>();
        public virtual ICollection<RegistroCumplimiento> RegistrosCumplimiento { get; set; } = new List<RegistroCumplimiento>();
    }
}
