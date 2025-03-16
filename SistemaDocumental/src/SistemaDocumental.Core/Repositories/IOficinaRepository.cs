using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IOficinaRepository
    {
        Oficina? ObtenerPorID(int id);
        List<Oficina> ObtenerTodas();
        void Agregar(Oficina oficina);
        void Eliminar(Oficina oficina);
    }
}
