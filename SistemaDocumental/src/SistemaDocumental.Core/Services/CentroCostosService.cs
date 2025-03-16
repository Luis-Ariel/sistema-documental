using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class CentroCostosService
    {
        private readonly ICentroCostosRepository _centroCostosRepository;

        public CentroCostosService(ICentroCostosRepository centroCostosRepository)
        {
            _centroCostosRepository = centroCostosRepository;
        }

        public int ObtenerID(CentroCostos centroCostos) => centroCostos.ID_Centro_Costos;

        public string ObtenerDescripcion(CentroCostos centroCostos) => centroCostos.Descripcion;

        public string ObtenerJefatura(CentroCostos centroCostos) => centroCostos.Jefatura;

        public List<Oficina> ObtenerOficinasRelacionadas(CentroCostos centroCostos)
            => _centroCostosRepository.ObtenerOficinasRelacionadas(centroCostos);

        public List<Usuario> ObtenerUsuariosRelacionados(CentroCostos centroCostos)
            => _centroCostosRepository.ObtenerUsuariosRelacionados(centroCostos);

        public void AgregarOficina(CentroCostos centroCostos, Oficina oficina)
            => _centroCostosRepository.AgregarOficina(centroCostos, oficina);

        public void EliminarOficina(CentroCostos centroCostos, Oficina oficina)
            => _centroCostosRepository.EliminarOficina(centroCostos, oficina);

        public void AgregarUsuario(CentroCostos centroCostos, Usuario usuario)
            => _centroCostosRepository.AgregarUsuario(centroCostos, usuario);

        public void EliminarUsuario(CentroCostos centroCostos, Usuario usuario)
            => _centroCostosRepository.EliminarUsuario(centroCostos, usuario);

        public string ObtenerEstructuraCompleta(CentroCostos centroCostos)
            => $"Centro Costos: {centroCostos.Descripcion}, Jefatura: {centroCostos.Jefatura}";
    }
}
