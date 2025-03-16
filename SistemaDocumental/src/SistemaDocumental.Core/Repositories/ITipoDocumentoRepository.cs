using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface ITipoDocumentoRepository
    {
        TipoDocumento? ObtenerPorID(int id);
        List<TipoDocumento> ObtenerTodos();
        List<TipoDocumento> BuscarPorNombre(string nombre);
    }
}
