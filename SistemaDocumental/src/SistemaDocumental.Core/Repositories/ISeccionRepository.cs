using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface ISeccionRepository
    {
        Seccion? ObtenerPorID(int id);
        List<Seccion> ObtenerTodas();
        void Agregar(Seccion seccion);
        void Eliminar(Seccion seccion);
    }
}
