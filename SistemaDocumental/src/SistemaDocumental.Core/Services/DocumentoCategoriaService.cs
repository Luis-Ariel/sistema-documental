using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Services
{
    public class DocumentoCategoriaService
    {
        private readonly IDocumentoCategoriaRepository _documentoCategoriaRepository;

        public DocumentoCategoriaService(IDocumentoCategoriaRepository documentoCategoriaRepository)
        {
            _documentoCategoriaRepository = documentoCategoriaRepository;
        }

        public Documento ObtenerDocumento(DocumentoCategoria documentoCategoria)
        {
            return documentoCategoria.Documento;
        }

        public Categoria ObtenerCategoria(DocumentoCategoria documentoCategoria)
        {
            return documentoCategoria.Categoria;
        }

        public List<Documento> ObtenerDocumentosPorCategoria(Categoria categoria)
        {
            return _documentoCategoriaRepository.ObtenerDocumentosPorCategoria(categoria);
        }

        public List<Categoria> ObtenerCategoriasPorDocumento(Documento documento)
        {
            return _documentoCategoriaRepository.ObtenerCategoriasPorDocumento(documento);
        }
    }
}
