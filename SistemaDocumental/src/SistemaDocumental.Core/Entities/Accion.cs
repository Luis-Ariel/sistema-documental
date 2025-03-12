using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDocumental.Core.Entities
{
    public class Accion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID generado automáticamente
        public int ID_Accion { get; set; }

        [Required]
        public TipoAccion Tipo { get; set; }

        [Required]
        public DateTime Fecha_Accion { get; set; } = DateTime.Now;

        [Required]
        public int ID_Usuario { get; set; }

        [Required]
        public int ID_Documento { get; set; }

        public string Detalles { get; set; }

        public bool Notificar { get; set; } = false;

        [MaxLength(255)]
        public string Notificacion_Detalle { get; set; }

        public int? ID_Operacion_Masiva { get; set; }
    }

    public enum TipoAccion
    {
        Subida,
        Descarga,
        Compartir,
        Eliminar,
        Imprimir,
        Modificacion,
        Validacion
    }
}
