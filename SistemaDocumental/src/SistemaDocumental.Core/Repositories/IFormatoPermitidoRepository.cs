using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IFormatoPermitidoRepository
    {
        FormatoPermitido? ObtenerPorID(int id);
        FormatoPermitido? ObtenerPorExtension(string extension);
        List<FormatoPermitido> ObtenerTodos();
        List<TipoDocumento> ObtenerTiposDeDocumento(int idFormato);
        List<Documento> ObtenerDocumentosPorFormato(int idFormato);
        void Agregar(FormatoPermitido formato);
        void Actualizar(FormatoPermitido formato);
        void Eliminar(int id);
    }
}
