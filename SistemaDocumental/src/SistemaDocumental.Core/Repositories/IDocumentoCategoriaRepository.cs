using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IDocumentoCategoriaRepository
    {
        List<Documento> ObtenerDocumentosPorCategoria(Categoria categoria);
        List<Categoria> ObtenerCategoriasPorDocumento(Documento documento);
    }
}
