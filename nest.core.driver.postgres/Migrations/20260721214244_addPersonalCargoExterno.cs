using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addPersonalCargoExterno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personal_cargo_externo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    PersonalId = table.Column<int>(type: "integer", nullable: false),
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_cargo_externo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_cargo_externo_cargo_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "rrhh",
                        principalTable: "cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_cargo_externo_personal_PersonalId",
                        column: x => x.PersonalId,
                        principalSchema: "rrhh",
                        principalTable: "personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_cargo_externo_audit",
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
                    CargoId = table.Column<int>(type: "integer", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_cargo_externo_audit", x => x.AuditId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personal_cargo_externo_CargoId",
                schema: "rrhh",
                table: "personal_cargo_externo",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_cargo_externo_EmpresaId",
                schema: "rrhh",
                table: "personal_cargo_externo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_cargo_externo_PersonalId_CargoId",
                schema: "rrhh",
                table: "personal_cargo_externo",
                columns: new[] { "PersonalId", "CargoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_cargo_externo_audit_Id",
                schema: "rrhh",
                table: "personal_cargo_externo_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personal_cargo_externo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "personal_cargo_externo_audit",
                schema: "rrhh");
        }
    }
}
