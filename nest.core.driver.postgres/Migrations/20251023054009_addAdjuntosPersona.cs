using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addAdjuntosPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona_audit");

            migrationBuilder.DropColumn(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona");

            migrationBuilder.CreateTable(
                name: "adjunto_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adjunto_tipo_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_tipo_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "persona_adjunto_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoTipoId = table.Column<int>(type: "integer", nullable: false),
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
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    EsFotoPrincipal = table.Column<bool>(type: "boolean", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona_adjunto_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "persona_adjunto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    PersonaId = table.Column<int>(type: "integer", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoTipoId = table.Column<int>(type: "integer", nullable: false),
                    EsFotoPrincipal = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona_adjunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_adjunto_adjunto_AdjuntoId",
                        column: x => x.AdjuntoId,
                        principalSchema: "dbo",
                        principalTable: "adjunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persona_adjunto_adjunto_tipo_AdjuntoTipoId",
                        column: x => x.AdjuntoTipoId,
                        principalSchema: "dbo",
                        principalTable: "adjunto_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persona_adjunto_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "adjunto_tipo",
                columns: new[] { "Id", "Activo", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { 1, true, "Fotografia", "Foto" },
                    { 2, true, "Dni", "Dni" },
                    { 3, true, "Licencia de conducir", "LDC" },
                    { 4, true, "Hoja de vida", "CV" },
                    { 5, true, "Contrato", "Contrato" },
                    { 6, true, "Habilitación", "HAB" },
                    { 99, true, "Otros", "Otros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_adjunto_tipo_audit_Id",
                schema: "dbo",
                table: "adjunto_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoTipoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_EmpresaId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_PersonaId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_audit_Id",
                schema: "dbo",
                table: "persona_adjunto_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adjunto_tipo_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "persona_adjunto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "persona_adjunto_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_tipo",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona_audit",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
