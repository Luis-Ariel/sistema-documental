using System;
using System.Collections.Generic;
using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Repositories;

namespace SistemaDocumental.Core.Services
{
    public class VersionHistorialService
    {
        private readonly IVersionHistorialRepository _versionHistorialRepository;

        public VersionHistorialService(IVersionHistorialRepository versionHistorialRepository)
        {
            _versionHistorialRepository = versionHistorialRepository;
        }

        public int ObtenerID(VersionHistorial version)
        {
            return version.ID_Registro;
        }

        public Documento ObtenerDocumento(VersionHistorial version)
        {
            return version.Documento;
        }

        public DateTime ObtenerFecha(VersionHistorial version)
        {
            return version.Fecha;
        }

        public Usuario ObtenerUsuarioModificador(VersionHistorial version)
        {
            return version.UsuarioModificador;
        }

        public Accion ObtenerAccion(VersionHistorial version)
        {
            return version.Accion;
        }

        public string ObtenerTitulo(VersionHistorial version)
        {
            return version.Titulo;
        }

        public string ObtenerDescripcion(VersionHistorial version)
        {
            return version.Descripcion;
        }

        public byte[] ObtenerContenido(VersionHistorial version)
        {
            return version.Contenido;
        }

        public string ObtenerHashIntegridad(VersionHistorial version)
        {
            return version.Hash_Integridad;
        }

        public void CrearNuevaVersion(Documento documento, Usuario usuario, Accion accion, string titulo, string descripcion, byte[] contenido, string hashIntegridad)
        {
            var nuevaVersion = new VersionHistorial
            {
                ID_Documento = documento.ID_Documento,
                Documento = documento,
                ID_UsuarioModificador = usuario.ID_Usuario,
                UsuarioModificador = usuario,
                ID_Accion = accion.ID_Accion,
                Accion = accion,
                Titulo = titulo,
                Descripcion = descripcion,
                Contenido = contenido,
                Hash_Integridad = hashIntegridad
            };

            _versionHistorialRepository.CrearNuevaVersion(nuevaVersion);
        }

        public bool ValidarIntegridad(string hash)
        {
            return _versionHistorialRepository.ValidarIntegridad(hash);
        }

        public List<VersionHistorial> ObtenerHistorialPorDocumento(int idDocumento)
        {
            return _versionHistorialRepository.ObtenerHistorialPorDocumento(idDocumento);
        }
    }
}
