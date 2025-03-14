using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ID_Grupo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Grupo { get; set; } = string.Empty; // Inicialización

        [Required]
        public int Nivel { get; set; } 

        public string Descripcion { get; set; } = string.Empty; // Inicialización

        [Required]
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now; 

        // Clave foránea: Rol padre en la jerarquía
        public int? ID_GrupoPadre { get; set; }

        [ForeignKey("ID_GrupoPadre")]
        public virtual Roles RolPadre { get; set; } = null!; // Inicialización con `null!`

        // Inicialización de colecciones para evitar valores `null`
        public virtual ICollection<Roles> RolesSubordinados { get; set; } = new List<Roles>();
        public virtual ICollection<AlertaDestinatario> AlertasRecibidas { get; set; } = new List<AlertaDestinatario>();
        public virtual ICollection<RolPermiso> PermisosRol { get; set; } = new List<RolPermiso>();
        public virtual ICollection<HistorialPermisos> HistorialPermisos { get; set; } = new List<HistorialPermisos>();
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public virtual ICollection<NotificacionEvento> NotificacionesRecibidas { get; set; } = new List<NotificacionEvento>();
    }
}
