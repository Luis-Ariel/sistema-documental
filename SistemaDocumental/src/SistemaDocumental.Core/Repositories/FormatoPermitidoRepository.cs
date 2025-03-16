using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Infrastructure.Repositories
{
    public class FormatoPermitidoRepository : IFormatoPermitidoRepository
    {
        private readonly List<FormatoPermitido> _formatos = new List<FormatoPermitido>();

        public FormatoPermitido? ObtenerPorID(int id)
        {
            return _formatos.FirstOrDefault(f => f.ID_Formato == id);
        }

        public FormatoPermitido? ObtenerPorExtension(string extension)
        {
            return _formatos.FirstOrDefault(f => f.Extension.ToLower() == extension.ToLower());
        }

        public List<FormatoPermitido> ObtenerTodos()
        {
            return _formatos;
        }

        public List<TipoDocumento> ObtenerTiposDeDocumento(int idFormato)
        {
            var formato = ObtenerPorID(idFormato);
            return formato != null ? formato.TiposDeDocumentos.ToList() : new List<TipoDocumento>();
        }

        public List<Documento> ObtenerDocumentosPorFormato(int idFormato)
        {
            return _formatos
                .Where(f => f.ID_Formato == idFormato)
                .SelectMany(f => f.TiposDeDocumentos)
                .SelectMany(t => t.Documentos)
                .ToList();
        }

        public void Agregar(FormatoPermitido formato)
        {
            _formatos.Add(formato);
        }

        public void Actualizar(FormatoPermitido formato)
        {
            var index = _formatos.FindIndex(f => f.ID_Formato == formato.ID_Formato);
            if (index != -1)
            {
                _formatos[index] = formato;
            }
        }

        public void Eliminar(int id)
        {
            _formatos.RemoveAll(f => f.ID_Formato == id);
        }
    }
}
