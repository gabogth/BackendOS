using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class otHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "orden_trabajo_horario",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_horario_horario_cabecera_HorarioCabeceraId",
                        column: x => x.HorarioCabeceraId,
                        principalSchema: "rrhh",
                        principalTable: "horario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_horario_orden_trabajo_cabecera_OrdenTrabajoCa~",
                        column: x => x.OrdenTrabajoCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_horario_personal_PersonalId",
                        column: x => x.PersonalId,
                        principalSchema: "rrhh",
                        principalTable: "personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orden_trabajo_horario_audit",
                schema: "mantto",
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
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_horario_audit", x => x.AuditId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_horario_EmpresaId",
                schema: "mantto",
                table: "orden_trabajo_horario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_horario_HorarioCabeceraId",
                schema: "mantto",
                table: "orden_trabajo_horario",
                column: "HorarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_horario_OrdenTrabajoCabeceraId",
                schema: "mantto",
                table: "orden_trabajo_horario",
                column: "OrdenTrabajoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_horario_PersonalId",
                schema: "mantto",
                table: "orden_trabajo_horario",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_horario_audit_Id",
                schema: "mantto",
                table: "orden_trabajo_horario_audit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                column: "UsuarioId",
                principalSchema: "security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.DropTable(
                name: "orden_trabajo_horario",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_horario_audit",
                schema: "mantto");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                column: "UsuarioId",
                principalSchema: "security",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
