using SistemaDocumental.Core.Entities;

namespace SistemaDocumental.Core.Repositories
{
    public interface IPermisoRepository
    {
        void ModificarNombre(Permiso permiso, string nuevoNombre);
        void ModificarNivelAcceso(Permiso permiso, string nuevoNivel);
        bool EliminarPermiso(Permiso permiso);
        bool EstaAsignado(Permiso permiso);
    }
}
