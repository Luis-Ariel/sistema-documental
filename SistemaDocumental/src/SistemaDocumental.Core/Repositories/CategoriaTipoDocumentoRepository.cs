using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Infrastructure.Repositories
{
    public class CategoriaTipoDocumentoRepository : ICategoriaTipoDocumentoRepository
    {
        private readonly List<CategoriaTipoDocumento> _categoriaTipoDocumentos = new List<CategoriaTipoDocumento>();

        public List<TipoDocumento> ObtenerTiposPorCategoria(Categoria categoria)
        {
            return _categoriaTipoDocumentos
                .Where(ctd => ctd.Categoria == categoria)
                .Select(ctd => ctd.TipoDocumento)
                .ToList();
        }

        public List<Categoria> ObtenerCategoriasPorTipoDocumento(TipoDocumento tipoDocumento)
        {
            return _categoriaTipoDocumentos
                .Where(ctd => ctd.TipoDocumento == tipoDocumento)
                .Select(ctd => ctd.Categoria)
                .ToList();
        }

        public List<Documento> ObtenerDocumentosPorCategoriaYTipo(Categoria categoria, TipoDocumento tipoDocumento)
        {
            return _categoriaTipoDocumentos
                .Where(ctd => ctd.Categoria == categoria && ctd.TipoDocumento == tipoDocumento)
                .SelectMany(ctd => ctd.TipoDocumento.Documentos)
                .ToList();
        }
    }
}
