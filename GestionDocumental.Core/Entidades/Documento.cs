using System;
using System.ComponentModel.DataAnnotations;

namespace GestionDocumental.Core.Entities
{
    public class Documento
    {
        [Key]
        public int ID_Documento { get; set; }

        public int ID_Tipo_Documento { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha_Subida { get; set; }

        public DateTime? Fecha_Modificacion { get; set; }

        [Required]
        public string Ruta_Archivo { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = "Creacion"; // ENUM: 'Creacion', 'Revision', etc.

        public int ID_UsuarioOrigen { get; set; }
        public int ID_UsuarioModificador { get; set; }
        public bool Validado { get; set; }
        public bool Necesita_Actualizar_Index { get; set; } = false;
        public bool Bloqueado { get; set; } = false;
        public float Relevancia { get; set; } = 0;
        public DateTime? Fecha_Validacion { get; set; }
        public byte[]? Firma_Electronica { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public DateTime? Ultima_Indexacion { get; set; }

        [Required]
        public string Formato_Descargable { get; set; } = "PDF"; // ENUM

        [Required]
        public string Formato_Imprimible { get; set; } = "A4"; // ENUM

        [Required]
        public string Hash_Integridad { get; set; } = string.Empty;
    }
}