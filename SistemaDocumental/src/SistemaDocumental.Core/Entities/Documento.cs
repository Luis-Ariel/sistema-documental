using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDocumental.Core.Entities.Enums;

namespace SistemaDocumental.Core.Entities
{
    public class Documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ID_Documento { get; set; }

        [Required]
        public int ID_TipoDocumento { get; set; }

        [ForeignKey("ID_TipoDocumento")]
        public virtual TipoDocumento TipoDocumento { get; set; } = null!; // Inicialización para evitar warning

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty; // Inicialización para evitar warning

        public DateTime Fecha_Subida { get; set; } = DateTime.Now;

        public DateTime? Fecha_Modificacion { get; set; }

        [Required]
        [MaxLength(500)]
        public string Ruta_Archivo { get; set; } = string.Empty; // Inicialización para evitar warning

        [Required]
        public EstadoDocumento Estado { get; set; }

        // Clave foránea para el usuario que creó el documento
        [Required]
        public int ID_UsuarioOrigen { get; set; }

        [ForeignKey("ID_UsuarioOrigen")]
        public virtual Usuario UsuarioOrigen { get; set; } = null!; // Inicialización para evitar warning

        // Clave foránea para el usuario que modificó el documento
        public int? ID_UsuarioModificador { get; set; }

        [ForeignKey("ID_UsuarioModificador")]
        public virtual Usuario? UsuarioModificador { get; set; } // Permitimos valores nulos

        public bool Validado { get; set; } = false;

        public bool Necesita_Actualizar_Index { get; set; } = false;

        public bool Bloqueado { get; set; } = false;

        public float Relevancia { get; set; } = 0;

        public DateTime? Fecha_Validacion { get; set; }

        public byte[] Firma_Electronica { get; set; } = new byte[0]; // Inicialización para evitar warning

        public DateTime? Fecha_Vencimiento { get; set; }

        public DateTime? Ultima_Indexacion { get; set; }

        [Required]
        public FormatoDescargable Formato_Descargable { get; set; }

        [Required]
        public FormatoImprimible Formato_Imprimible { get; set; }

        [Required]
        [MaxLength(256)]
        public string Hash_Integridad { get; set; } = string.Empty; // Inicialización para evitar warning

        // Relación 1-N: Un documento puede estar asociado a múltiples acciones
        public virtual ICollection<Accion> Acciones { get; set; } = new List<Accion>();

        // Relación 1-N: Un documento puede tener múltiples alertas asociadas
        public virtual ICollection<AlertaDocumento> Alertas { get; set; } = new List<AlertaDocumento>();

        // Relación 1-N: Un documento puede estar en múltiples DocumentoCategoria
        public virtual ICollection<DocumentoCategoria> CategoriasDocumento { get; set; } = new List<DocumentoCategoria>();

        // Relación 1-N: Un documento puede tener múltiples versiones en el historial
        public virtual ICollection<VersionHistorial> VersionesHistorial { get; set; } = new List<VersionHistorial>();

        // Relación 1-N: Un documento puede tener múltiples registros de cumplimiento
        public virtual ICollection<RegistroCumplimiento> RegistrosCumplimiento { get; set; } = new List<RegistroCumplimiento>();
    }
}
