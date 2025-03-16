using SistemaDocumental.Core.Entities;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IDepartamentoRepository
    {
        Departamento? ObtenerPorID(int id);
        List<Departamento> ObtenerTodos();
        void Agregar(Departamento departamento);
        void Eliminar(Departamento departamento);
    }
}
