using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface ICategoriaRepository
    {
        List<Documento> ObtenerDocumentos(Categoria categoria);
        List<TipoDocumento> ObtenerTiposDeDocumento(Categoria categoria);
        List<Categoria> BuscarPorNombre(string nombre);
    }
}
