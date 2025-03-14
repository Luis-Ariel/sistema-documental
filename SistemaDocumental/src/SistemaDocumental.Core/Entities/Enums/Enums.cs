namespace SistemaDocumental.Core.Entities.Enums
{
    // Enum para definir los niveles de acceso de los permisos
    public enum NivelAcceso
    {
        Lectura,
        Escritura,
        Edicion,
        Eliminacion
    }

    // Enum para definir el tipo de acción en el sistema
    public enum TipoAccion
    {
        Subida,
        Descarga,
        Compartir,
        Eliminar,
        Imprimir,
        Modificacion, // Solo esta acción generará un VersionHistorial
        Validacion
    }

    // Enum para definir los estados de los documentos
    public enum EstadoDocumento
    {
        Creacion,
        Revision,
        Aprobacion,
        Archivado,
        Eliminado
    }

    // Enum para definir los roles predeterminados en el sistema
    public enum TipoRol
    {
        Administrador,
        Usuario,
        Auditor
    }

    public enum TipoCambioPermiso
    {
        Asignado,
        Modificado,
        Eliminado
    }

    public enum TipoDocumentacion
    {
        GuiaUsuario,
        FAQ,
        ManualTecnico
    }

    public enum EstadoNotificacion
    {
        Pendiente,
        Enviado,
        Cancelado
    }

    public enum EstadoSesion
    {
        Activa,
        Expirada,
        Cerrada
    }

    public enum FormatoDescargable
    {
        Original,
        PDF,
        DOCX,
        XLSX
    }

    public enum FormatoImprimible
    {
        Original,
        PDF,
        A4,
        Carta
    }

    public enum TipoAlerta
    {
        Modificacion,
        Eliminacion,
        Vencimiento
    }
}
