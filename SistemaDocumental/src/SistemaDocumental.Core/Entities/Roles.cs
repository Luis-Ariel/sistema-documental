using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Grupo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Grupo { get; set; } // Nombre del rol o grupo

        [Required]
        public int Nivel { get; set; } // Nivel jerárquico del rol

        public string Descripcion { get; set; } // Descripción opcional del grupo

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now; // Fecha de creación del rol

        // Clave foránea: Rol padre en la jerarquía
        public int? ID_GrupoPadre { get; set; }

        [ForeignKey("ID_GrupoPadre")]
        public virtual Rol RolPadre { get; set; }

        // Relación 1-N: Un rol puede tener varios roles subordinados
        public virtual ICollection<Rol> RolesSubordinados { get; set; } = new List<Rol>();

        // Relación 1-N: Un rol puede ser destinatario de múltiples alertas
        public virtual ICollection<AlertaDestinatario> AlertasRecibidas { get; set; } = new List<AlertaDestinatario>();

        // Relación 1-N: Un rol puede tener múltiples permisos a través de RolPermiso
        public virtual ICollection<RolPermiso> PermisosRol { get; set; } = new List<RolPermiso>();

        // Relación 1-N: Un rol puede tener múltiples permisos modificados en el historial
        public virtual ICollection<HistorialPermisos> HistorialPermisos { get; set; } = new List<HistorialPermisos>();

        // Relación 1-N: Un rol puede estar asignado a múltiples usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        // Relación 1-N: Un rol puede ser destinatario de múltiples notificaciones
        public virtual ICollection<NotificacionEvento> NotificacionesRecibidas { get; set; } = new List<NotificacionEvento>();
    }
}
