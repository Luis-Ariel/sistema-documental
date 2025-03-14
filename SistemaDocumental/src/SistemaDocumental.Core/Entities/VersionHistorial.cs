using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class VersionHistorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Registro { get; set; }

        [Required]
        public int ID_Documento { get; set; }

        [ForeignKey("ID_Documento")]
        public virtual Documento Documento { get; set; } = null!; // Evita valores nulos y warnings

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int ID_UsuarioModificador { get; set; }

        [ForeignKey("ID_UsuarioModificador")]
        public virtual Usuario UsuarioModificador { get; set; } = null!;

        // Clave foránea: Acción que generó la versión del historial
        [Required]
        public int ID_Accion { get; set; }

        [ForeignKey("ID_Accion")]
        public virtual Accion Accion { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public byte[] Contenido { get; set; } = Array.Empty<byte>(); // Inicializa el contenido como un array vacío

        [Required]
        [MaxLength(256)]
        public string Hash_Integridad { get; set; } = string.Empty; // Evita valores nulos

        // Constructor vacío necesario para Entity Framework
        public VersionHistorial() { }

        // Constructor con parámetros para asegurar valores no nulos
        public VersionHistorial(int idDocumento, int idUsuarioModificador, int idAccion, string titulo, string hashIntegridad)
        {
            ID_Documento = idDocumento;
            ID_UsuarioModificador = idUsuarioModificador;
            ID_Accion = idAccion;
            Titulo = titulo;
            Hash_Integridad = hashIntegridad;
        }
    }
}
