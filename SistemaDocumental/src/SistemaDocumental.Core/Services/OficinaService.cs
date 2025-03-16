using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDocumental.Core.Services
{
    public class OficinaService
    {
        private readonly IOficinaRepository _oficinaRepository;

        public OficinaService(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }

        public int ObtenerID(Oficina oficina)
        {
            return oficina.ID_Oficina;
        }

        public string ObtenerNombre(Oficina oficina)
        {
            return oficina.Nombre_Oficina;
        }

        public Seccion ObtenerSeccion(Oficina oficina)
        {
            return oficina.Seccion;
        }

        public CentroCostos ObtenerCentroCostos(Oficina oficina)
        {
            return oficina.CentroCostos;
        }

        public List<Usuario> ObtenerUsuarios(Oficina oficina)
        {
            return oficina.Usuarios.ToList();
        }

        public void AgregarUsuario(Oficina oficina, Usuario usuario)
        {
            if (!oficina.Usuarios.Contains(usuario))
            {
                oficina.Usuarios.Add(usuario);
            }
        }

        public void EliminarUsuario(Oficina oficina, Usuario usuario)
        {
            if (oficina.Usuarios.Contains(usuario))
            {
                oficina.Usuarios.Remove(usuario);
            }
        }

        public string ObtenerEstructuraCompleta(Oficina oficina)
        {
            return $"{oficina.CentroCostos.Jefatura} > {oficina.CentroCostos.Descripcion} > {oficina.Nombre_Oficina}";
        }
    }
}
