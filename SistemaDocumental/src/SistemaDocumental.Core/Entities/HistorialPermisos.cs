using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Entities
{
    public class HistorialPermisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Historial { get; set; }

        // Clave foránea: Usuario que realizó el cambio de permisos
        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public virtual Usuario Usuario { get; set; } = null!; // Evita warnings de valores nulos

        [Required]
        public int ID_Permiso { get; set; }

        [ForeignKey("ID_Permiso")]
        public virtual Permiso Permiso { get; set; } = null!;

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha del cambio

        [Required]
        public TipoCambioPermiso Tipo_Cambio { get; set; } // Tipo de cambio realizado

        // Clave foránea: Grupo (Rol) que recibió la modificación de permisos (opcional)
        public int? ID_Grupo { get; set; }

        [ForeignKey("ID_Grupo")]
        public virtual Roles? Grupo { get; set; } // Puede ser nulo

        [Required]
        public NivelAcceso Nivel_Acceso { get; set; } // Nivel de acceso del permiso

        public string Descripcion { get; set; } = string.Empty; // Evita valores nulos en descripciones

        // Constructor vacío para Entity Framework
        public HistorialPermisos() { }

        // Constructor con parámetros obligatorios para evitar nulos
        public HistorialPermisos(int idUsuario, int idPermiso, TipoCambioPermiso tipoCambio, NivelAcceso nivelAcceso, string descripcion = "")
        {
            ID_Usuario = idUsuario;
            ID_Permiso = idPermiso;
            Tipo_Cambio = tipoCambio;
            Nivel_Acceso = nivelAcceso;
            Descripcion = descripcion;
        }
    }
}
