using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly List<Categoria> _categorias = new List<Categoria>();

        public List<Documento> ObtenerDocumentos(Categoria categoria)
        {
            return categoria.DocumentosCategoria.Select(dc => dc.Documento).ToList();
        }

        public List<TipoDocumento> ObtenerTiposDeDocumento(Categoria categoria)
        {
            return categoria.TiposDeDocumentos.Select(ctd => ctd.TipoDocumento).ToList();
        }


        public List<Categoria> BuscarPorNombre(string nombre)
        {
            return _categorias.Where(c => c.Nombre_Categoria.Contains(nombre)).ToList();
        }
    }
}
