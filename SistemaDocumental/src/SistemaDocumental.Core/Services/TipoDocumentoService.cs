using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class TipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public int ObtenerID(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.ID_Tipo_Documento;
        }

        public string ObtenerNombre(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.Nombre_Tipo;
        }

        public string ObtenerDescripcion(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.Descripcion;
        }

        public FormatoPermitido ObtenerFormatoPermitido(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.FormatoPermitido;
        }

        public List<Documento> ObtenerDocumentos(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.Documentos.ToList();
        }

        public List<Categoria> ObtenerCategoriasRelacionadas(TipoDocumento tipoDocumento)
        {
            return tipoDocumento.CategoriasTipoDocumento.Select(ctd => ctd.Categoria).ToList();
        }

        public List<TipoDocumento> BuscarPorNombre(string nombre)
        {
            return _tipoDocumentoRepository.BuscarPorNombre(nombre);
        }
    }
}
