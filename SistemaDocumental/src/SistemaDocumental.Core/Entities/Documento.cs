using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Documento { get; set; }

        [Required]
        public int ID_Tipo_Documento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        public DateTime Fecha_Subida { get; set; } = DateTime.Now;

        public DateTime? Fecha_Modificacion { get; set; }

        [Required]
        [MaxLength(500)]
        public string Ruta_Archivo { get; set; }

        [Required]
        public EstadoDocumento Estado { get; set; }

        public int ID_UsuarioOrigen { get; set; }

        public int? ID_UsuarioModificador { get; set; }

        public bool Validado { get; set; } = false;

        public bool Necesita_Actualizar_Index { get; set; } = false;

        public bool Bloqueado { get; set; } = false;

        public float Relevancia { get; set; } = 0;

        public DateTime? Fecha_Validacion { get; set; }

        public byte[] Firma_Electronica { get; set; }

        public DateTime? Fecha_Vencimiento { get; set; }

        public DateTime? Ultima_Indexacion { get; set; }

        [Required]
        public FormatoDescargable Formato_Descargable { get; set; }

        [Required]
        public FormatoImprimible Formato_Imprimible { get; set; }

        [Required]
        [MaxLength(256)]
        public string Hash_Integridad { get; set; }
    }

    public enum EstadoDocumento
    {
        Creacion,
        Revision,
        Aprobacion,
        Archivado,
        Eliminado
    }

    public enum FormatoDescargable
    {
        Original,
        PDF,
        DOCX,
        XLSX
    }

    public enum FormatoImprimible
    {
        Original,
        PDF,
        A4,
        Carta
    }
}
