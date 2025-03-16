using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface ICentroCostosRepository
    {
        CentroCostos? ObtenerPorID(int id);
        List<Oficina> ObtenerOficinasRelacionadas(CentroCostos centroCostos);
        List<Usuario> ObtenerUsuariosRelacionados(CentroCostos centroCostos);
        void AgregarOficina(CentroCostos centroCostos, Oficina oficina);
        void EliminarOficina(CentroCostos centroCostos, Oficina oficina);
        void AgregarUsuario(CentroCostos centroCostos, Usuario usuario);
        void EliminarUsuario(CentroCostos centroCostos, Usuario usuario);
    }
}
