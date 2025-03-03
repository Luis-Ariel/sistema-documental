namespace GestionDocumental.Core.Entities
{
    public class Documento
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }  // Usa "required" para evitar el warning
        public required string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}