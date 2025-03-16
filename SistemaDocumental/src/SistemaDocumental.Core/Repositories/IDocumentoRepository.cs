using SistemaDocumental.Core.Entities;
using SistemaDocumental.Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace SistemaDocumental.Core.Repositories
{
    public interface IDocumentoRepository
    {
        Documento? ObtenerPorID(int id);
        List<Documento> ObtenerTodos();
        List<Documento> BuscarPorTitulo(string titulo);
        List<Documento> BuscarPorCategoria(Categoria categoria);
        List<Documento> BuscarPorTipo(TipoDocumento tipo);
        List<Documento> BuscarPorAutor(Usuario usuario);
        List<Documento> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin);
        List<Documento> OrdenarPorRelevancia();
        List<Documento> OrdenarPorFecha(bool descendente);
        void Actualizar(Documento documento);

        // Métodos agregados según el diagrama de clases y DocumentoRepository
        void CambiarEstado(int idDocumento, EstadoDocumento nuevoEstado);
        List<Categoria> ObtenerCategorias(int idDocumento);
        void AsignarCategoria(int idDocumento, Categoria categoria);
        void EliminarCategoria(int idDocumento, Categoria categoria);
        bool ValidarFormato(int idDocumento, string formato);
        List<VersionHistorial> ObtenerVersiones(int idDocumento);
        void CrearNuevaVersion(int idDocumento, Usuario usuario, TipoAccion accion);
        void BloquearDocumento(int idDocumento);
        void DesbloquearDocumento(int idDocumento);
        bool VerificarIntegridad(int idDocumento, string hash);
        void ActualizarRelevancia(int idDocumento, float nuevaRelevancia);
        void MarcarParaReindexacion(int idDocumento);
        void ValidarDocumento(int idDocumento);
        bool EsVencido(int idDocumento);
        void GuardarDocumento(Documento documento);
        void EliminarDocumento(int id);
    }
}

