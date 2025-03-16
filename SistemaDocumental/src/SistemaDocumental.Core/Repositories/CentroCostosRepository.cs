using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Infrastructure.Repositories
{
    public class CentroCostosRepository : ICentroCostosRepository
    {
        private readonly List<CentroCostos> _centrosCostos = new();

    public CentroCostos ObtenerPorID(int id)
        => _centrosCostos.FirstOrDefault(cc => cc.ID_Centro_Costos == id)
            ?? throw new InvalidOperationException("No se encontró el Centro de Costos.");

        public List<Oficina> ObtenerOficinasRelacionadas(CentroCostos centroCostos)
            => centroCostos.OficinasRelacionadas.ToList();

        public List<Usuario> ObtenerUsuariosRelacionados(CentroCostos centroCostos)
            => centroCostos.UsuariosRelacionados.ToList();

        public void AgregarOficina(CentroCostos centroCostos, Oficina oficina)
        {
            if (!centroCostos.OficinasRelacionadas.Contains(oficina))
                centroCostos.OficinasRelacionadas.Add(oficina);
        }

        public void EliminarOficina(CentroCostos centroCostos, Oficina oficina)
        {
            if (centroCostos.OficinasRelacionadas.Contains(oficina))
                centroCostos.OficinasRelacionadas.Remove(oficina);
        }

        public void AgregarUsuario(CentroCostos centroCostos, Usuario usuario)
        {
            if (!centroCostos.UsuariosRelacionados.Contains(usuario))
                centroCostos.UsuariosRelacionados.Add(usuario);
        }

        public void EliminarUsuario(CentroCostos centroCostos, Usuario usuario)
        {
            if (centroCostos.UsuariosRelacionados.Contains(usuario))
                centroCostos.UsuariosRelacionados.Remove(usuario);
        }
    }
}
