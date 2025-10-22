using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addAdjuntos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adjunto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContentType = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoProvider = table.Column<byte>(type: "smallint", nullable: false),
                    Container = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FullPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NombreGenerado = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adjunto_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoProvider = table.Column<byte>(type: "smallint", nullable: false),
                    AuditAccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuditHost = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "boolean", nullable: false),
                    AuditMethod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Container = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ContentType = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FileName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FullPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NombreGenerado = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "adjunto_config",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AdjuntoProvider = table.Column<byte>(type: "smallint", nullable: false),
                    Container = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MainPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adjunto_config_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    AdjuntoProvider = table.Column<byte>(type: "smallint", nullable: false),
                    AuditAccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuditHost = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "boolean", nullable: false),
                    AuditMethod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Container = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MainPath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_config_audit", x => x.AuditId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "adjunto_config",
                columns: new[] { "Id", "Activo", "AdjuntoProvider", "Container", "MainPath", "Nombre", "NombreCorto" },
                values: new object[] { 1, false, (byte)3, "Container", "/usuarios/fotos", "USUARIOS_FOTOS_REPO", "USRFOTBKT" });

            migrationBuilder.CreateIndex(
                name: "IX_adjunto_audit_Id",
                schema: "dbo",
                table: "adjunto_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_adjunto_config_audit_Id",
                schema: "dbo",
                table: "adjunto_config_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adjunto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_config",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_config_audit",
                schema: "dbo");
        }
    }
}
