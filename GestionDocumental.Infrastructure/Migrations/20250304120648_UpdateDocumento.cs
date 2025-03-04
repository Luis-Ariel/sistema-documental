using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDocumental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Documentos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Documentos",
                newName: "Ruta_Archivo");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Documentos",
                newName: "Fecha_Vencimiento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Documentos",
                newName: "ID_Documento");

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Documentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Modificacion",
                table: "Documentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Subida",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Validacion",
                table: "Documentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Firma_Electronica",
                table: "Documentos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formato_Descargable",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Formato_Imprimible",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hash_Integridad",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID_Tipo_Documento",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_UsuarioModificador",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_UsuarioOrigen",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Necesita_Actualizar_Index",
                table: "Documentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Relevancia",
                table: "Documentos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ultima_Indexacion",
                table: "Documentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validado",
                table: "Documentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Fecha_Modificacion",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Fecha_Subida",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Fecha_Validacion",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Firma_Electronica",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Formato_Descargable",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Formato_Imprimible",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Hash_Integridad",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ID_Tipo_Documento",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ID_UsuarioModificador",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ID_UsuarioOrigen",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Necesita_Actualizar_Index",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Relevancia",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Ultima_Indexacion",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Validado",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Documentos",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Ruta_Archivo",
                table: "Documentos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Fecha_Vencimiento",
                table: "Documentos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "ID_Documento",
                table: "Documentos",
                newName: "Id");
        }
    }
}
