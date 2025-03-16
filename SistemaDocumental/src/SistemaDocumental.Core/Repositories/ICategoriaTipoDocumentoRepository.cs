using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface ICategoriaTipoDocumentoRepository
    {
        List<TipoDocumento> ObtenerTiposPorCategoria(Categoria categoria);
        List<Categoria> ObtenerCategoriasPorTipoDocumento(TipoDocumento tipoDocumento);
        List<Documento> ObtenerDocumentosPorCategoriaYTipo(Categoria categoria, TipoDocumento tipoDocumento);
    }
}
