using GestionDocumental.Core.Entities;
using GestionDocumental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GestionDocumental.Infrastructure.Services
{
    public class DocumentosService
    {
        private readonly ApplicationDbContext _context;

        public DocumentosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Documento>> GetAllAsync()
        {
            return await _context.Documentos.ToListAsync();
        }

        public async Task<Documento?> GetByIdAsync(int id)
        {
            return await _context.Documentos.FindAsync(id);
        }

        public async Task<Documento> CreateAsync(Documento documento)
        {
            _context.Documentos.Add(documento);
            await _context.SaveChangesAsync();
            return documento;
        }

        public async Task<bool> UpdateAsync(Documento documento)
        {
            var existing = await _context.Documentos.FindAsync(documento.Id);
            if (existing == null) return false;

            existing.Nombre = documento.Nombre;
            existing.Tipo = documento.Tipo;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null) return false;

            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}