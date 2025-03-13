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
        public bool Activo { get; set; } = true; // Estado del usuario (activo/inactivo)

        // Clave foránea: Grupo (Rol) al que pertenece el usuario
        [Required]
        public int ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Rol Grupo { get; set; }

        public int ID_Oficina { get; set; }

        [ForeignKey("ID_Oficina")]
        public virtual Oficina Oficina { get; set; }

        public int ID_Centro_Costos { get; set; }

        [ForeignKey("ID_Centro_Costos")]
        public virtual CentroCostos CentroCostos { get; set; }

        // Relación 1-N: Un usuario puede haber subido muchos documentos
        public virtual ICollection<Documento> DocumentosCreados { get; set; } = new List<Documento>();

        // Relación 1-N: Un usuario puede haber modificado muchos documentos
        public virtual ICollection<Documento> DocumentosModificados { get; set; } = new List<Documento>();
        
        // Relación 1-N: Un usuario puede realizar muchas acciones
        public virtual ICollection<Accion> AccionesRealizadas { get; set; } = new List<Accion>();

        // Relación 1-N: Un usuario puede recibir múltiples notificaciones
        public virtual ICollection<NotificacionEvento> Notificaciones { get; set; } = new List<NotificacionEvento>();

        // Relación 1-N: Un usuario puede haber modificado múltiples versiones de documentos
        public virtual ICollection<VersionHistorial> VersionesHistorialModificadas { get; set; } = new List<VersionHistorial>();

        // Relación 1-N: Un usuario puede haber modificado múltiples permisos
        public virtual ICollection<HistorialPermisos> CambiosPermisos { get; set; } = new List<HistorialPermisos>();

        // Relación 1-N: Un usuario puede ser destinatario de múltiples alertas
        public virtual ICollection<AlertaDestinatario> AlertasRecibidas { get; set; } = new List<AlertaDestinatario>();

        // Relación 1-N: Un usuario puede haber iniciado múltiples sesiones
        public virtual ICollection<SesionUsuario> Sesiones { get; set; } = new List<SesionUsuario>();

        // Relación 1-N: Un usuario puede haber sido responsable de múltiples registros de cumplimiento
        public virtual ICollection<RegistroCumplimiento> RegistrosCumplimiento { get; set; } = new List<RegistroCumplimiento>();
    }
}
