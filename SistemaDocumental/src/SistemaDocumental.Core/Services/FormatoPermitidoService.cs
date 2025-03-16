using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Services
{
    public class FormatoPermitidoService
    {
        private readonly IFormatoPermitidoRepository _formatoRepository;

        public FormatoPermitidoService(IFormatoPermitidoRepository formatoRepository)
        {
            _formatoRepository = formatoRepository;
        }

        public FormatoPermitido? ObtenerPorID(int id)
        {
            return _formatoRepository.ObtenerPorID(id);
        }

        public FormatoPermitido? ObtenerPorExtension(string extension)
        {
            return _formatoRepository.ObtenerPorExtension(extension);
        }

        public List<FormatoPermitido> ObtenerTodos()
        {
            return _formatoRepository.ObtenerTodos();
        }

        public List<TipoDocumento> ObtenerTiposDeDocumento(int idFormato)
        {
            return _formatoRepository.ObtenerTiposDeDocumento(idFormato);
        }

        public List<Documento> ObtenerDocumentosPorFormato(int idFormato)
        {
            return _formatoRepository.ObtenerDocumentosPorFormato(idFormato);
        }

        public void Agregar(FormatoPermitido formato)
        {
            _formatoRepository.Agregar(formato);
        }

        public void Actualizar(FormatoPermitido formato)
        {
            _formatoRepository.Actualizar(formato);
        }

        public void Eliminar(int id)
        {
            _formatoRepository.Eliminar(id);
        }
    }
}
