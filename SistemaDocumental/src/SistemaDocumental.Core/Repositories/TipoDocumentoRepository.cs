using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly List<TipoDocumento> _tiposDocumento = new List<TipoDocumento>();

        public TipoDocumento? ObtenerPorID(int id)
        {
            return _tiposDocumento.FirstOrDefault(td => td.ID_Tipo_Documento == id);
        }

        public List<TipoDocumento> ObtenerTodos()
        {
            return _tiposDocumento;
        }

        public List<TipoDocumento> BuscarPorNombre(string nombre)
        {
            return _tiposDocumento.Where(td => td.Nombre_Tipo.Contains(nombre)).ToList();
        }
    }
}
