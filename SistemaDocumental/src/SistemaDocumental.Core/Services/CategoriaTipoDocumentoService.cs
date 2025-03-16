using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Services
{
    public class CategoriaTipoDocumentoService
    {
        private readonly ICategoriaTipoDocumentoRepository _categoriaTipoDocumentoRepository;

        public CategoriaTipoDocumentoService(ICategoriaTipoDocumentoRepository categoriaTipoDocumentoRepository)
        {
            _categoriaTipoDocumentoRepository = categoriaTipoDocumentoRepository;
        }

        public List<TipoDocumento> ObtenerTiposPorCategoria(Categoria categoria)
        {
            return _categoriaTipoDocumentoRepository.ObtenerTiposPorCategoria(categoria);
        }

        public List<Categoria> ObtenerCategoriasPorTipoDocumento(TipoDocumento tipoDocumento)
        {
            return _categoriaTipoDocumentoRepository.ObtenerCategoriasPorTipoDocumento(tipoDocumento);
        }

        public List<Documento> ObtenerDocumentosPorCategoriaYTipo(Categoria categoria, TipoDocumento tipoDocumento)
        {
            return _categoriaTipoDocumentoRepository.ObtenerDocumentosPorCategoriaYTipo(categoria, tipoDocumento);
        }
    }
}
