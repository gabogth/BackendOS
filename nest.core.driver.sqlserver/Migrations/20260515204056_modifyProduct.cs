using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nest.core.driver.sqlserver.Migrations
{
    /// <inheritdoc />
    public partial class modifyProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.DropIndex(
                name: "IX_usuario_empresa_EmpresaId_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.DropIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId",
                schema: "rrhh",
                table: "grupo_trabajo_persona");

            migrationBuilder.DropColumn(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle_audit");

            migrationBuilder.DropColumn(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia_audit",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia_audit",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductoId",
                schema: "logistica",
                table: "producto_lote_audit",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductoId",
                schema: "logistica",
                table: "producto_lote",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "logistica",
                table: "producto_audit",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "logistica",
                table: "producto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal_audit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductoId",
                schema: "logistica",
                table: "inventario_detalle_audit",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductoId",
                schema: "logistica",
                table: "inventario_detalle",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera_audit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera_audit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera_audit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "adjunto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoProvider = table.Column<byte>(type: "tinyint", nullable: false),
                    Container = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreGenerado = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    AdjuntoProvider = table.Column<byte>(type: "tinyint", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Container = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NombreGenerado = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdjuntoProvider = table.Column<byte>(type: "tinyint", nullable: false),
                    Container = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MainPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
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
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    AdjuntoProvider = table.Column<byte>(type: "tinyint", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Container = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MainPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_config_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "adjunto_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
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
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adjunto_tipo_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "orden_trabajo_horario",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_orden_trabajo_horario_orden_trabajo_cabecera_OrdenTrabajoCabeceraId",
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
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_horario_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "persona_adjunto_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoTipoId = table.Column<int>(type: "int", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    EsFotoPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona_adjunto_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "registro_asistencia_adjunto_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_adjunto_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "registro_asistencia_orden_trabajo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_orden_trabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registro_asistencia_orden_trabajo_orden_trabajo_cabecera_OrdenTrabajoCabeceraId",
                        column: x => x.OrdenTrabajoCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registro_asistencia_orden_trabajo_registro_asistencia_Id",
                        column: x => x.Id,
                        principalSchema: "rrhh",
                        principalTable: "registro_asistencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registro_asistencia_orden_trabajo_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditApp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAppVersion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditAssemblyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIpRemoteOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditIsHttps = table.Column<bool>(type: "bit", nullable: false),
                    AuditMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditOrigin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditProtocol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditReferer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditRequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUserAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuditUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_orden_trabajo_audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "registro_asistencia_adjunto",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_asistencia_adjunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registro_asistencia_adjunto_adjunto_AdjuntoId",
                        column: x => x.AdjuntoId,
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
                name: "persona_adjunto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    AdjuntoId = table.Column<long>(type: "bigint", nullable: false),
                    AdjuntoTipoId = table.Column<int>(type: "int", nullable: false),
                    EsFotoPrincipal = table.Column<bool>(type: "bit", nullable: false)
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
                table: "adjunto_config",
                columns: new[] { "Id", "Activo", "AdjuntoProvider", "Container", "MainPath", "Nombre", "NombreCorto" },
                values: new object[] { 1, false, (byte)3, "Container", "/usuarios/fotos", "USUARIOS_FOTOS_REPO", "USRFOTBKT" });

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
                name: "IX_usuario_empresa_EmpresaId_UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                columns: new[] { "EmpresaId", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_UsuarioId",
                schema: "rrhh",
                table: "personal",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId_PersonaId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                columns: new[] { "GrupoTrabajoId", "PersonaId" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_adjunto_tipo_audit_Id",
                schema: "dbo",
                table: "adjunto_tipo_audit",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_persona_adjunto_AdjuntoId",
                schema: "dbo",
                table: "persona_adjunto",
                column: "AdjuntoId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_adjunto_AdjuntoId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
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

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_orden_trabajo_EmpresaId",
                schema: "rrhh",
                table: "registro_asistencia_orden_trabajo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_orden_trabajo_OrdenTrabajoCabeceraId",
                schema: "rrhh",
                table: "registro_asistencia_orden_trabajo",
                column: "OrdenTrabajoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_orden_trabajo_audit_Id",
                schema: "rrhh",
                table: "registro_asistencia_orden_trabajo_audit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_personal_AspNetUsers_UsuarioId",
                schema: "rrhh",
                table: "personal",
                column: "UsuarioId",
                principalSchema: "security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_personal_AspNetUsers_UsuarioId",
                schema: "rrhh",
                table: "personal");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_empresa_AspNetUsers_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.DropTable(
                name: "adjunto_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_config",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_config_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto_tipo_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "orden_trabajo_horario",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_horario_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "persona_adjunto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "persona_adjunto_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "registro_asistencia_adjunto_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "registro_asistencia_orden_trabajo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "registro_asistencia_orden_trabajo_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "adjunto_tipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjunto",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_usuario_empresa_EmpresaId_UsuarioId",
                schema: "security",
                table: "usuario_empresa");

            migrationBuilder.DropIndex(
                name: "IX_personal_UsuarioId",
                schema: "rrhh",
                table: "personal");

            migrationBuilder.DropIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId_PersonaId",
                schema: "rrhh",
                table: "grupo_trabajo_persona");

            migrationBuilder.DropColumn(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia_audit");

            migrationBuilder.DropColumn(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia_audit");

            migrationBuilder.DropColumn(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia");

            migrationBuilder.DropColumn(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal_audit");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal");

            migrationBuilder.DropColumn(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera_audit");

            migrationBuilder.DropColumn(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera");

            migrationBuilder.DropColumn(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera_audit");

            migrationBuilder.DropColumn(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera_audit");

            migrationBuilder.DropColumn(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera");

            migrationBuilder.DropColumn(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "logistica",
                table: "producto_lote_audit",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "logistica",
                table: "producto_lote",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "logistica",
                table: "producto_audit",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "logistica",
                table: "producto",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "logistica",
                table: "inventario_detalle_audit",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                schema: "logistica",
                table: "inventario_detalle",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle_audit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "int",
                maxLength: 9,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_empresa_EmpresaId_UsuarioId",
                schema: "security",
                table: "usuario_empresa",
                columns: new[] { "EmpresaId", "UsuarioId" },
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                column: "GrupoTrabajoId");

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
