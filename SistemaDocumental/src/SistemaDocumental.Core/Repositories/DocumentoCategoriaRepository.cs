using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class DocumentoCategoriaRepository : IDocumentoCategoriaRepository
    {
        private readonly List<DocumentoCategoria> _documentosCategorias = new List<DocumentoCategoria>();

        public List<Documento> ObtenerDocumentosPorCategoria(Categoria categoria)
        {
            return _documentosCategorias
                .Where(dc => dc.Categoria == categoria)
                .Select(dc => dc.Documento)
                .ToList();
        }

        public List<Categoria> ObtenerCategoriasPorDocumento(Documento documento)
        {
            return _documentosCategorias
                .Where(dc => dc.Documento == documento)
                .Select(dc => dc.Categoria)
                .ToList();
        }
    }
}
