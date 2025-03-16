using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public int ObtenerID(Categoria categoria)
        {
            return categoria.ID_Categoria;
        }

        public string ObtenerNombre(Categoria categoria)
        {
            return categoria.Nombre_Categoria;
        }

        public string ObtenerDescripcion(Categoria categoria)
        {
            return categoria.Descripcion;
        }

        public List<Documento> ObtenerDocumentos(Categoria categoria)
        {
            return _categoriaRepository.ObtenerDocumentos(categoria);
        }

        public List<TipoDocumento> ObtenerTiposDeDocumento(Categoria categoria)
        {
            return _categoriaRepository.ObtenerTiposDeDocumento(categoria);
        }

        public List<Categoria> BuscarPorNombre(string nombre)
        {
            return _categoriaRepository.BuscarPorNombre(nombre);
        }
    }
}
