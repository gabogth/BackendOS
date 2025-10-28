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
            migrationBuilder.DropForeignKey(
                name: "FK_persona_adjunto_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto");

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
                name: "IX_registro_asistencia_adjunto_EmpresaId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_adjunto_audit_Id",
                schema: "rrhh",
                table: "registro_asistencia_adjunto_audit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adjunto_persona_adjunto_Id",
                schema: "dbo",
                table: "adjunto",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "persona_adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_adjunto_registro_asistencia_adjunto_Id",
                schema: "dbo",
                table: "adjunto",
                column: "Id",
                principalSchema: "rrhh",
                principalTable: "registro_asistencia_adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_asistencia_registro_asistencia_adjunto_Id",
                schema: "rrhh",
                table: "registro_asistencia",
                column: "Id",
                principalSchema: "rrhh",
                principalTable: "registro_asistencia_adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adjunto_persona_adjunto_Id",
                schema: "dbo",
                table: "adjunto");

            migrationBuilder.DropForeignKey(
                name: "FK_adjunto_registro_asistencia_adjunto_Id",
                schema: "dbo",
                table: "adjunto");

            migrationBuilder.DropForeignKey(
                name: "FK_registro_asistencia_registro_asistencia_adjunto_Id",
                schema: "rrhh",
                table: "registro_asistencia");

            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto_audit",
                schema: "rrhh");

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_adjunto_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId",
                principalSchema: "dbo",
                principalTable: "adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
