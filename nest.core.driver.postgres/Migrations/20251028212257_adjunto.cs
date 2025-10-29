using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class adjunto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto");

            migrationBuilder.CreateTable(
                name: "registro_asistencia_adjunto",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_adjunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registro_asistencia_adjunto_adjunto_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "adjunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registro_asistencia_adjunto_registro_asistencia_Id",
                        column: x => x.Id,
                        principalSchema: "rrhh",
                        principalTable: "registro_asistencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registro_asistencia_adjunto_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_adjunto_audit", x => x.AuditId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_adjunto_EmpresaId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_adjunto_audit_Id",
                schema: "rrhh",
                table: "registro_asistencia_adjunto_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto_audit",
                schema: "rrhh");

            migrationBuilder.DropIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId");
        }
    }
}
