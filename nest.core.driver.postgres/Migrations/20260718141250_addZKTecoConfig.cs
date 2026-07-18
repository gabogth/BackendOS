using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addZKTecoConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "terminal_biometrico",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SN = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminal_biometrico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "terminal_biometrico_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SN = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminal_biometrico_audit", x => x.AuditId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_terminal_biometrico_audit_Id",
                schema: "rrhh",
                table: "terminal_biometrico_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "terminal_biometrico",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "terminal_biometrico_audit",
                schema: "rrhh");
        }
    }
}
