using GestionDocumental.Core.Entities;
using GestionDocumental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionDocumental.Infrastructure.Services
{
    public class DocumentosService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DocumentosService> _logger; // Inyección de logger para mejor rastreo

        public DocumentosService(ApplicationDbContext context, ILogger<DocumentosService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Documento>> GetAllAsync()
        {
            try
            {
                return await _context.Documentos.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los documentos.");
                throw new Exception("Ocurrió un error al obtener los documentos. Inténtelo nuevamente.");
            }
        }

        public async Task<Documento?> GetByIdAsync(int id)
        {
            try
            {
                var documento = await _context.Documentos.FindAsync(id);
                if (documento == null)
                {
                    throw new KeyNotFoundException($"No se encontró un documento con el ID {id}.");
                }

                return documento;
            }
            catch (KeyNotFoundException ex)
            {
                throw; // No encapsulamos este error para que el controlador lo maneje correctamente.
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al buscar el documento con ID {id}.", ex);
            }
        }


        public async Task<Documento> CreateAsync(Documento documento)
        {
            try
            {
                _context.Documentos.Add(documento);
                await _context.SaveChangesAsync();
                return documento;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al insertar el documento en la base de datos.");
                throw new Exception("No se pudo guardar el documento en la base de datos. Verifique los datos e intente nuevamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear el documento.");
                throw new Exception("Ocurrió un error al crear el documento. Inténtelo nuevamente.");
            }
        }

        public async Task<bool> UpdateAsync(Documento documento)
        {
            try
            {
                var existing = await _context.Documentos.FindAsync(documento.ID_Documento);
                if (existing == null)
                {
                    _logger.LogWarning($"Intento de actualizar un documento no encontrado con ID {documento.ID_Documento}.");
                    throw new KeyNotFoundException($"No se encontró un documento con el ID {documento.ID_Documento}.");
                }

                _context.Entry(existing).CurrentValues.SetValues(documento);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, $"Error de concurrencia al actualizar el documento con ID {documento.ID_Documento}.");
                throw new Exception("No se pudo actualizar el documento debido a un conflicto. Inténtelo nuevamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado al actualizar el documento con ID {documento.ID_Documento}.");
                throw new Exception("Ocurrió un error al actualizar el documento. Inténtelo nuevamente.");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var documento = await _context.Documentos.FindAsync(id);
                if (documento == null)
                {
                    _logger.LogWarning($"Intento de eliminar un documento no encontrado con ID {id}.");
                    throw new KeyNotFoundException($"No se encontró un documento con el ID {id}.");
                }

                _context.Documentos.Remove(documento);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error al eliminar el documento con ID {id}. Puede estar relacionado con otras entidades.");
                throw new Exception("No se pudo eliminar el documento porque está relacionado con otros registros.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado al eliminar el documento con ID {id}.");
                throw new Exception("Ocurrió un error al eliminar el documento. Inténtelo nuevamente.");
            }
        }
    }
}
  