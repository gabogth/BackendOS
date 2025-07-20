﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nest.core.security.Migrations.MySql
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "patrimonial");

            migrationBuilder.EnsureSchema(
                name: "logistica");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.EnsureSchema(
                name: "rrhh");

            migrationBuilder.EnsureSchema(
                name: "costos");

            migrationBuilder.EnsureSchema(
                name: "legal");

            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.EnsureSchema(
                name: "contabilidad");

            migrationBuilder.EnsureSchema(
                name: "finanzas");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "organizacion");

            migrationBuilder.EnsureSchema(
                name: "aplicacion");

            migrationBuilder.EnsureSchema(
                name: "mantto");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "activo_audit",
                schema: "patrimonial",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CentroDeCostosId = table.Column<int>(type: "int", nullable: true),
                    DepreciacionMeses = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ImagenUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductoLoteId = table.Column<long>(type: "bigint", nullable: true),
                    TerceroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "almacen_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacen_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens_audit",
                schema: "security",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "centro_de_costos",
                schema: "costos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsFinal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PadreId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centro_de_costos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_centro_de_costos_centro_de_costos_PadreId",
                        column: x => x.PadreId,
                        principalSchema: "costos",
                        principalTable: "centro_de_costos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "centro_de_costos_audit",
                schema: "costos",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsFinal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PadreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centro_de_costos_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_cabecera_audit",
                schema: "legal",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoTipoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaInicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resumen = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_detalle_audit",
                schema: "legal",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    FechaFirma = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaUltimaNotificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Firmo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_detalle_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_personal_audit",
                schema: "legal",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    EstructuraOrganizacionalId = table.Column<int>(type: "int", nullable: false),
                    MontoBruto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_personal_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_tipo",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_tipo_audit",
                schema: "legal",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "correlativo_maestro",
                schema: "audit",
                columns: table => new
                {
                    Schema = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Table = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastValue = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_correlativo_maestro", x => new { x.Schema, x.Table });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_contable_audit",
                schema: "contabilidad",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContableTipoId = table.Column<int>(type: "int", nullable: false),
                    ES = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    NombreCorto = table.Column<int>(type: "int", nullable: false),
                    PadreId = table.Column<int>(type: "int", nullable: true),
                    PermiteMovimiento = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_contable_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_contable_tipo",
                schema: "contabilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_contable_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_contable_tipo_audit",
                schema: "contabilidad",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_contable_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_corriente_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContableId = table.Column<int>(type: "int", nullable: false),
                    CuentaNumero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntidadFinancieraId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_corriente_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "distrito_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distrito_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento_identidad_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_identidad_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento_identidad_tipo_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_identidad_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoEstatal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento_tipo_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoEstatal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entidad_financiera",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsEfectivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entidad_financiera", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entidad_financiera_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsEfectivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entidad_financiera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estructura_organizacional_audit",
                schema: "organizacion",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EstructuraOrganizacionalTipoId = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Final = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioRegistro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estructura_organizacional_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estructura_organizacional_tipo",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estructura_organizacional_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estructura_organizacional_tipo_audit",
                schema: "organizacion",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estructura_organizacional_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_cabecera_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comentarios = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoTipoGenId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumentoGen = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrigenFinancieroId = table.Column<short>(type: "smallint", nullable: false),
                    PuntoFinancieroId = table.Column<int>(type: "int", nullable: false),
                    SerieDocumentoGen = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerceroGenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_detalle_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaCorrienteId = table.Column<int>(type: "int", nullable: true),
                    DocumentoTipoId = table.Column<int>(type: "int", nullable: false),
                    ES = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinancieroCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerieDocumento = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerceroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_detalle_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_logistica_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinancieroDetalleId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventarioCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_logistica_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_orden_servicio_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinancieroDetalleId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenServicioCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_orden_servicio_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formulario_audit",
                schema: "aplicacion",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Controlador = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Icono = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Orden = table.Column<short>(type: "smallint", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formulario_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_horario",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraEntrada = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    HoraSalida = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    DiferenciaDia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_horario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_horario_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiferenciaDia = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    HoraSalida = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_horario_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_trabajo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    NombreCorto = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_trabajo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_trabajo_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    NombreCorto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_trabajo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_trabajo_persona_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsLider = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GrupoTrabajoId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_trabajo_persona_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horario_cabecera",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario_cabecera", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horario_cabecera_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horario_detalle_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaSemana = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    GrupoHorarioId = table.Column<int>(type: "int", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario_detalle_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_cabecera_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoNumero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoSerie = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoTipoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LogisticaTransaccionId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_detalle_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventarioCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    Item = table.Column<short>(type: "smallint", nullable: false),
                    Nota = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductoLoteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_detalle_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "labor",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "labor_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labor_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "licencia_conducir",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nivel = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licencia_conducir", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "licencia_conducir_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nivel = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licencia_conducir_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "logistica_transaccion",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ES = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistica_transaccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "logistica_transaccion_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ES = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistica_transaccion_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mantenimiento_tipo",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mantenimiento_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mantenimiento_tipo_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mantenimiento_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modulo",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RutaImagen = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Controlador = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modulo_audit",
                schema: "aplicacion",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Controlador = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RutaImagen = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "moneda",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prefix = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sufix = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Simbolo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneda", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "moneda_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prefix = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Simbolo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sufix = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneda_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_cabecera_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoOrdenInterna = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoReferencial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenServicioTipoId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_mantenimiento_externo_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    ActaConformidadId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPI = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClientePlannerId = table.Column<int>(type: "int", nullable: false),
                    ClienteSupervisorId = table.Column<int>(type: "int", nullable: true),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: true),
                    CotizacionId = table.Column<int>(type: "int", nullable: false),
                    FechaEntregaCorreo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaEntregaInforme = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFianzaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFianzaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPagoFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcionFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcionHES = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimientoFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LicitacionCodigo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MantenimientoTipoId = table.Column<short>(type: "smallint", nullable: false),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    MontoBruto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MontoFianza = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MontoNeto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    NumeroFactura = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroHES = table.Column<int>(type: "int", nullable: false),
                    ReporteCalidad = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReporteMedicion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorFacturadoNeto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_mantenimiento_externo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_tipo",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_tipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_tipo_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_tipo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_cabecera_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    FechaCompromiso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GrupoTrabajoId = table.Column<long>(type: "bigint", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrdenServicioCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraPadreId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_cabecera_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_detalle_activo_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    ActivoId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_detalle_activo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_detalle_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    HorasEjecutadas = table.Column<int>(type: "int", nullable: false),
                    HorasProyectadas = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LaborId = table.Column<int>(type: "int", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    UbicacionTecnicaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_detalle_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_personal_audit",
                schema: "mantto",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsLider = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_personal_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "origen_financiero",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Naturaleza = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origen_financiero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "origen_financiero_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Naturaleza = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origen_financiero_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoIso = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoTelefono = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoIso = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoTelefono = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoIdentidadTipoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LicenciaConducirId = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Nombres = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SexoId = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MarcaAsistencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PersonalEstadoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SuperiorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_estado",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_estado_audit",
                schema: "rrhh",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_estado_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Factor = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PuedeGenerarNuevosLotes = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UnidadMedidaCompraId = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaConsumoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto_lote_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventarioDetalleCreacionId = table.Column<long>(type: "bigint", nullable: true),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PrecioConsumo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    SerialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_lote_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "provincia_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincia_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "punto_financiero",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punto_financiero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "punto_financiero_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punto_financiero_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sexo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sexo_audit",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tercero_audit",
                schema: "finanzas",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContablePorCobrarId = table.Column<int>(type: "int", nullable: false),
                    CuentaContablePorPagarId = table.Column<int>(type: "int", nullable: false),
                    DireccionFiscal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoIdentidadFinanciero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoIdentidadTipoFinancieroId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tercero_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ubicacion_activo_audit",
                schema: "patrimonial",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    ActivoId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comentario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UbicacionTecnicaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicacion_activo_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ubicacion_tecnica_audit",
                schema: "patrimonial",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PadreId = table.Column<long>(type: "bigint", nullable: true),
                    TerceroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicacion_tecnica_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unidad_medida",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prefix = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad_medida", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unidad_medida_audit",
                schema: "logistica",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    AuditAcceptLanguage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAppVersion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditAssemblyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditContentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditCurrentCulture = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditFecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditHost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIpRemoteOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditIsHttps = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuditMethod = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditOrigin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlatform = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditProtocol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditQueryString = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditReferer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditRequestId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUserAgent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditUsuario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prefix = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad_medida_audit", x => x.AuditId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_cabecera",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ContratoTipoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resumen = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_cabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contrato_cabecera_contrato_tipo_ContratoTipoId",
                        column: x => x.ContratoTipoId,
                        principalSchema: "legal",
                        principalTable: "contrato_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_contable",
                schema: "contabilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    NombreCorto = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ES = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContableTipoId = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    PadreId = table.Column<int>(type: "int", nullable: true),
                    PermiteMovimiento = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_contable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuenta_contable_cuenta_contable_PadreId",
                        column: x => x.PadreId,
                        principalSchema: "contabilidad",
                        principalTable: "cuenta_contable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cuenta_contable_cuenta_contable_tipo_CuentaContableTipoId",
                        column: x => x.CuentaContableTipoId,
                        principalSchema: "contabilidad",
                        principalTable: "cuenta_contable_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estructura_organizacional",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    EstructuraOrganizacionalTipoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Final = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estructura_organizacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estructura_organizacional_estructura_organizacional_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "organizacion",
                        principalTable: "estructura_organizacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_estructura_organizacional_estructura_organizacional_tipo_Est~",
                        column: x => x.EstructuraOrganizacionalTipoId,
                        principalSchema: "organizacion",
                        principalTable: "estructura_organizacional_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horario_detalle",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    GrupoHorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_horario_detalle_grupo_horario_GrupoHorarioId",
                        column: x => x.GrupoHorarioId,
                        principalSchema: "rrhh",
                        principalTable: "grupo_horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horario_detalle_horario_cabecera_HorarioCabeceraId",
                        column: x => x.HorarioCabeceraId,
                        principalSchema: "rrhh",
                        principalTable: "horario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formulario",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Controlador = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icono = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Orden = table.Column<short>(type: "smallint", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formulario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_formulario_formulario_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "aplicacion",
                        principalTable: "formulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_formulario_modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalSchema: "aplicacion",
                        principalTable: "modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_cabecera",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenServicioTipoId = table.Column<short>(type: "smallint", nullable: false),
                    CodigoOrdenInterna = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoReferencial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_cabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_servicio_cabecera_orden_servicio_tipo_OrdenServicioTip~",
                        column: x => x.OrdenServicioTipoId,
                        principalSchema: "mantto",
                        principalTable: "orden_servicio_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_PaisId",
                        column: x => x.PaisId,
                        principalSchema: "dbo",
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadMedidaCompraId = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaConsumoId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PuedeGenerarNuevosLotes = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_unidad_medida_UnidadMedidaCompraId",
                        column: x => x.UnidadMedidaCompraId,
                        principalSchema: "logistica",
                        principalTable: "unidad_medida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_producto_unidad_medida_UnidadMedidaConsumoId",
                        column: x => x.UnidadMedidaConsumoId,
                        principalSchema: "logistica",
                        principalTable: "unidad_medida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuenta_corriente",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CuentaNumero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntidadFinancieraId = table.Column<int>(type: "int", nullable: false),
                    CuentaContableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta_corriente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuenta_corriente_cuenta_contable_CuentaContableId",
                        column: x => x.CuentaContableId,
                        principalSchema: "contabilidad",
                        principalTable: "cuenta_contable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cuenta_corriente_entidad_financiera_EntidadFinancieraId",
                        column: x => x.EntidadFinancieraId,
                        principalSchema: "finanzas",
                        principalTable: "entidad_financiera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_cabecera",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenServicioCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCompromiso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GrupoTrabajoId = table.Column<long>(type: "bigint", nullable: true),
                    OrdenTrabajoCabeceraPadreId = table.Column<long>(type: "bigint", nullable: true),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_cabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_cabecera_grupo_trabajo_GrupoTrabajoId",
                        column: x => x.GrupoTrabajoId,
                        principalSchema: "rrhh",
                        principalTable: "grupo_trabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_cabecera_orden_servicio_cabecera_OrdenServicio~",
                        column: x => x.OrdenServicioCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_servicio_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_cabecera_orden_trabajo_cabecera_OrdenTrabajoCa~",
                        column: x => x.OrdenTrabajoCabeceraPadreId,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "provincia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_provincia_departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalSchema: "dbo",
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto_lote",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    SerialId = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PrecioConsumo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    InventarioDetalleCreacionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_lote_moneda_MonedaId",
                        column: x => x.MonedaId,
                        principalSchema: "finanzas",
                        principalTable: "moneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_lote_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "logistica",
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "distrito",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_distrito_provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalSchema: "dbo",
                        principalTable: "provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "almacen",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCorto = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_almacen_distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalSchema: "dbo",
                        principalTable: "distrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SexoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    LicenciaConducirId = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    DocumentoIdentidadTipoId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DistritoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalSchema: "dbo",
                        principalTable: "distrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_documento_identidad_tipo_DocumentoIdentidadTipoId",
                        column: x => x.DocumentoIdentidadTipoId,
                        principalSchema: "dbo",
                        principalTable: "documento_identidad_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persona_licencia_conducir_LicenciaConducirId",
                        column: x => x.LicenciaConducirId,
                        principalSchema: "dbo",
                        principalTable: "licencia_conducir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persona_sexo_SexoId",
                        column: x => x.SexoId,
                        principalSchema: "dbo",
                        principalTable: "sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_cabecera",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    LogisticaTransaccionId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DocumentoTipoId = table.Column<int>(type: "int", nullable: false),
                    DocumentoSerie = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoNumero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacion = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_cabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventario_cabecera_almacen_AlmacenId",
                        column: x => x.AlmacenId,
                        principalSchema: "logistica",
                        principalTable: "almacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventario_cabecera_documento_tipo_DocumentoTipoId",
                        column: x => x.DocumentoTipoId,
                        principalSchema: "dbo",
                        principalTable: "documento_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventario_cabecera_logistica_transaccion_LogisticaTransacci~",
                        column: x => x.LogisticaTransaccionId,
                        principalSchema: "logistica",
                        principalTable: "logistica_transaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_detalle",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    FechaUltimaNotificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Firmo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaFirma = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contrato_detalle_contrato_cabecera_ContratoCabeceraId",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrato_detalle_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato_personal",
                schema: "legal",
                columns: table => new
                {
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    EstructuraOrganizacionalId = table.Column<int>(type: "int", nullable: false),
                    MontoBruto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_personal", x => x.ContratoCabeceraId);
                    table.ForeignKey(
                        name: "FK_contrato_personal_cargo_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "rrhh",
                        principalTable: "cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contrato_personal_contrato_cabecera_ContratoCabeceraId",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrato_personal_estructura_organizacional_EstructuraOrgani~",
                        column: x => x.EstructuraOrganizacionalId,
                        principalSchema: "organizacion",
                        principalTable: "estructura_organizacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contrato_personal_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_trabajo_persona",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    GrupoTrabajoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EsLider = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_trabajo_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_grupo_trabajo_persona_grupo_trabajo_GrupoTrabajoId",
                        column: x => x.GrupoTrabajoId,
                        principalSchema: "rrhh",
                        principalTable: "grupo_trabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_trabajo_persona_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_personal",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EsLider = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_personal_orden_trabajo_cabecera_OrdenTrabajoCa~",
                        column: x => x.OrdenTrabajoCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_personal_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MarcaAsistencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    SuperiorId = table.Column<int>(type: "int", nullable: true),
                    PersonalEstadoId = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_contrato_cabecera_ContratoCabeceraId",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_horario_cabecera_HorarioCabeceraId",
                        column: x => x.HorarioCabeceraId,
                        principalSchema: "rrhh",
                        principalTable: "horario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_persona_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personal_personal_SuperiorId",
                        column: x => x.SuperiorId,
                        principalSchema: "rrhh",
                        principalTable: "personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_personal_estado_PersonalEstadoId",
                        column: x => x.PersonalEstadoId,
                        principalSchema: "rrhh",
                        principalTable: "personal_estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tercero",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DocumentoIdentidadTipoFinancieroId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DocumentoIdentidadFinanciero = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionFiscal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContablePorCobrarId = table.Column<int>(type: "int", nullable: false),
                    CuentaContablePorPagarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tercero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tercero_cuenta_contable_CuentaContablePorCobrarId",
                        column: x => x.CuentaContablePorCobrarId,
                        principalSchema: "contabilidad",
                        principalTable: "cuenta_contable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_cuenta_contable_CuentaContablePorPagarId",
                        column: x => x.CuentaContablePorPagarId,
                        principalSchema: "contabilidad",
                        principalTable: "cuenta_contable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_documento_identidad_tipo_DocumentoIdentidadTipoFinan~",
                        column: x => x.DocumentoIdentidadTipoFinancieroId,
                        principalSchema: "dbo",
                        principalTable: "documento_identidad_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_persona_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_detalle",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventarioCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    Item = table.Column<short>(type: "smallint", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductoLoteId = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventario_detalle_inventario_cabecera_InventarioCabeceraId",
                        column: x => x.InventarioCabeceraId,
                        principalSchema: "logistica",
                        principalTable: "inventario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_detalle_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "logistica",
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventario_detalle_producto_lote_ProductoLoteId",
                        column: x => x.ProductoLoteId,
                        principalSchema: "logistica",
                        principalTable: "producto_lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "activo",
                schema: "patrimonial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductoLoteId = table.Column<long>(type: "bigint", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepreciacionMeses = table.Column<int>(type: "int", nullable: true),
                    CentroDeCostosId = table.Column<int>(type: "int", nullable: true),
                    ImagenUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerceroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activo_centro_de_costos_CentroDeCostosId",
                        column: x => x.CentroDeCostosId,
                        principalSchema: "costos",
                        principalTable: "centro_de_costos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_activo_producto_lote_ProductoLoteId",
                        column: x => x.ProductoLoteId,
                        principalSchema: "logistica",
                        principalTable: "producto_lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_activo_tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalSchema: "finanzas",
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_cabecera",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PuntoFinancieroId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    OrigenFinancieroId = table.Column<short>(type: "smallint", nullable: false),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Comentarios = table.Column<string>(type: "longtext", maxLength: -1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerceroGenId = table.Column<int>(type: "int", nullable: false),
                    DocumentoTipoGenId = table.Column<int>(type: "int", nullable: false),
                    SerieDocumentoGen = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroDocumentoGen = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_cabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_financiero_cabecera_documento_tipo_DocumentoTipoGenId",
                        column: x => x.DocumentoTipoGenId,
                        principalSchema: "dbo",
                        principalTable: "documento_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_cabecera_origen_financiero_OrigenFinancieroId",
                        column: x => x.OrigenFinancieroId,
                        principalSchema: "finanzas",
                        principalTable: "origen_financiero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_cabecera_punto_financiero_PuntoFinancieroId",
                        column: x => x.PuntoFinancieroId,
                        principalSchema: "finanzas",
                        principalTable: "punto_financiero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_cabecera_tercero_TerceroGenId",
                        column: x => x.TerceroGenId,
                        principalSchema: "finanzas",
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio_mantenimiento_externo",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteSupervisorId = table.Column<int>(type: "int", nullable: true),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: true),
                    ClientePlannerId = table.Column<int>(type: "int", nullable: false),
                    CotizacionId = table.Column<int>(type: "int", nullable: false),
                    ActaConformidadId = table.Column<long>(type: "bigint", nullable: false),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    LicitacionCodigo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPI = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEntregaCorreo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFianzaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFianzaFinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MontoBruto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MontoNeto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MontoFianza = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReporteMedicion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReporteCalidad = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEntregaInforme = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcionHES = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumeroHES = table.Column<int>(type: "int", nullable: false),
                    MantenimientoTipoId = table.Column<short>(type: "smallint", nullable: false),
                    NumeroFactura = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorFacturadoNeto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcionFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimientoFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPagoFactura = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio_mantenimiento_externo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_contrato_cabecera_ActaC~",
                        column: x => x.ActaConformidadId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_contrato_cabecera_Contr~",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_mantenimiento_tipo_Mant~",
                        column: x => x.MantenimientoTipoId,
                        principalSchema: "mantto",
                        principalTable: "mantenimiento_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_moneda_MonedaId",
                        column: x => x.MonedaId,
                        principalSchema: "finanzas",
                        principalTable: "moneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_orden_servicio_cabecera~",
                        column: x => x.Id,
                        principalSchema: "mantto",
                        principalTable: "orden_servicio_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_persona_ClientePlannerId",
                        column: x => x.ClientePlannerId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_persona_ClienteSupervis~",
                        column: x => x.ClienteSupervisorId,
                        principalSchema: "dbo",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_servicio_mantenimiento_externo_tercero_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "finanzas",
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ubicacion_tecnica",
                schema: "patrimonial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TerceroId = table.Column<int>(type: "int", nullable: true),
                    PadreId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicacion_tecnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ubicacion_tecnica_tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalSchema: "finanzas",
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ubicacion_tecnica_ubicacion_tecnica_PadreId",
                        column: x => x.PadreId,
                        principalSchema: "patrimonial",
                        principalTable: "ubicacion_tecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_detalle",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FinancieroCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    TerceroId = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DocumentoTipoId = table.Column<int>(type: "int", nullable: false),
                    SerieDocumento = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroDocumento = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CuentaCorrienteId = table.Column<int>(type: "int", nullable: true),
                    ES = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_financiero_detalle_cuenta_corriente_CuentaCorrienteId",
                        column: x => x.CuentaCorrienteId,
                        principalSchema: "finanzas",
                        principalTable: "cuenta_corriente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_detalle_documento_tipo_DocumentoTipoId",
                        column: x => x.DocumentoTipoId,
                        principalSchema: "dbo",
                        principalTable: "documento_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_detalle_financiero_cabecera_FinancieroCabeceraId",
                        column: x => x.FinancieroCabeceraId,
                        principalSchema: "finanzas",
                        principalTable: "financiero_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_financiero_detalle_tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalSchema: "finanzas",
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_detalle",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrdenTrabajoCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    UbicacionTecnicaId = table.Column<long>(type: "bigint", nullable: false),
                    LaborId = table.Column<int>(type: "int", nullable: false),
                    HorasProyectadas = table.Column<int>(type: "int", nullable: false),
                    HorasEjecutadas = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_detalle_labor_LaborId",
                        column: x => x.LaborId,
                        principalSchema: "mantto",
                        principalTable: "labor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_detalle_orden_trabajo_cabecera_OrdenTrabajoCab~",
                        column: x => x.OrdenTrabajoCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_detalle_ubicacion_tecnica_UbicacionTecnicaId",
                        column: x => x.UbicacionTecnicaId,
                        principalSchema: "patrimonial",
                        principalTable: "ubicacion_tecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ubicacion_activo",
                schema: "patrimonial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ActivoId = table.Column<long>(type: "bigint", nullable: false),
                    UbicacionTecnicaId = table.Column<long>(type: "bigint", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCabeceraId = table.Column<long>(type: "bigint", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ubicacion_activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ubicacion_activo_activo_ActivoId",
                        column: x => x.ActivoId,
                        principalSchema: "patrimonial",
                        principalTable: "activo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ubicacion_activo_contrato_cabecera_ContratoCabeceraId",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ubicacion_activo_ubicacion_tecnica_UbicacionTecnicaId",
                        column: x => x.UbicacionTecnicaId,
                        principalSchema: "patrimonial",
                        principalTable: "ubicacion_tecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_logistica",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FinancieroDetalleId = table.Column<long>(type: "bigint", nullable: false),
                    InventarioCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_logistica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_financiero_logistica_financiero_detalle_FinancieroDetalleId",
                        column: x => x.FinancieroDetalleId,
                        principalSchema: "finanzas",
                        principalTable: "financiero_detalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_logistica_inventario_cabecera_InventarioCabeceraId",
                        column: x => x.InventarioCabeceraId,
                        principalSchema: "logistica",
                        principalTable: "inventario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financiero_orden_servicio",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FinancieroDetalleId = table.Column<long>(type: "bigint", nullable: false),
                    OrdenServicioCabeceraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financiero_orden_servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_financiero_orden_servicio_financiero_detalle_FinancieroDetal~",
                        column: x => x.FinancieroDetalleId,
                        principalSchema: "finanzas",
                        principalTable: "financiero_detalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_financiero_orden_servicio_orden_servicio_cabecera_OrdenServi~",
                        column: x => x.OrdenServicioCabeceraId,
                        principalSchema: "mantto",
                        principalTable: "orden_servicio_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_trabajo_detalle_activo",
                schema: "mantto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ActivoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_trabajo_detalle_activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_detalle_activo_activo_ActivoId",
                        column: x => x.ActivoId,
                        principalSchema: "patrimonial",
                        principalTable: "activo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orden_trabajo_detalle_activo_orden_trabajo_detalle_Id",
                        column: x => x.Id,
                        principalSchema: "mantto",
                        principalTable: "orden_trabajo_detalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                schema: "security",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "admin", "ADMIN" },
                    { "2", null, "superadmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "86354a26-1cc5-4918-9d33-b049f317e4c6", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEEeIExr86pRBXxafhFYbABge03ZqCG07elyWRluknySUeu0QYQn2AbIwIiLjMFraDQ==", null, false, "6632853f-901c-4e10-b69e-2a5e3018b060", false, "admin@admin.com" },
                    { "2", 0, "c0c88fd7-3561-4fdc-a51a-10cd2bce8b2b", "superadmin@admin.com", true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKk+GO+B1NIsiNc/9KsK7AcTcO2tYtYYVTAS3O053hE4W+ZIvEw1OF4GAhSMb1X/OA==", null, false, "a25d6514-15b8-4c24-90cd-33de18fc4440", false, "superadmin@admin.com" }
                });

            migrationBuilder.InsertData(
                schema: "rrhh",
                table: "cargo",
                columns: new[] { "Id", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "BACKEND SPECIALIST" },
                    { 2, true, "TEACH LEAD" },
                    { 3, true, "CONTADOR" }
                });

            migrationBuilder.InsertData(
                schema: "legal",
                table: "contrato_tipo",
                columns: new[] { "Id", "Detalle", "Nombre" },
                values: new object[,]
                {
                    { (byte)1, "CONTRATO DE PRESTACION DE SERVICIOS", "CONTRATO DE PRESTACION DE SERVICIOS" },
                    { (byte)2, "CONTRATO POR INCREMENTO DE OBRA", "CONTRATO POR INCREMENTO DE OBRA" },
                    { (byte)3, "CONTRATACION ADMINISTRATIVA DE SERVICIOS", "CAS" },
                    { (byte)4, "RECIBO POR HONORARIOS", "RECIBO POR HONORARIOS" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "documento_identidad_tipo",
                columns: new[] { "Id", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { (byte)1, "Documento nacional de identidad", "DNI" },
                    { (byte)2, "Carnet de extranjería", "CE" },
                    { (byte)3, "Pasaporte", "PSX" },
                    { (byte)4, "Permiso temporal de permanencia", "PTP" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "licencia_conducir",
                columns: new[] { "Id", "Nivel", "Nombre" },
                values: new object[,]
                {
                    { (byte)1, (byte)1, "AIA" },
                    { (byte)2, (byte)2, "AIIA" },
                    { (byte)3, (byte)3, "AIIB" },
                    { (byte)4, (byte)4, "AIIIA" },
                    { (byte)5, (byte)5, "AIIIB" },
                    { (byte)6, (byte)6, "AIIIC" },
                    { (byte)7, (byte)7, "B1" },
                    { (byte)8, (byte)8, "BIIA" },
                    { (byte)9, (byte)9, "BIIB" }
                });

            migrationBuilder.InsertData(
                schema: "logistica",
                table: "logistica_transaccion",
                columns: new[] { "Id", "ES", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { 1, "E", "INGRESO POR COMPRA", "ICOMPRA" },
                    { 2, "E", "INGRESO POR INICIO DE OPERACIONES", "IOPERAC" },
                    { 3, "E", "INGRESO POR DIFERENCIA DE INVENTARIO", "IDIFINV" },
                    { 4, "E", "INGRESO POR TRANFERENCIA", "ITRANSF" },
                    { 5, "E", "INGRESO POR PRODUCCION", "IPRODUC" },
                    { 101, "S", "SALIDA POR VENTA", "SVENTA" },
                    { 102, "S", "SALIDA POR CIERRE DE OPERACIONES", "SOPERAC" },
                    { 103, "S", "SALIDA POR DIFERENCIA DE INVENTARIO", "SDIFINV" },
                    { 104, "S", "SALIDA POR TRANSFERENCIA", "STRANSF" },
                    { 105, "E", "SALIDA POR PRODUCCION", "SPRODUC" }
                });

            migrationBuilder.InsertData(
                schema: "aplicacion",
                table: "modulo",
                columns: new[] { "Id", "Action", "Controlador", "Descripcion", "Estado", "Nombre", "NombreCorto", "RutaImagen" },
                values: new object[,]
                {
                    { 1, "Index", "Seguridad", "Modulo donde se setean los roles, permisos y menús.", true, "Seguridad", "SECURITY", "" },
                    { 2, "Index", "Logistica", "Modulo de inventarios logistica y transferencias.", true, "Logistica", "LOGISTIC", "" },
                    { 3, "Index", "VentasHome", "Modulo de facturacion, ventas, caja.", true, "Ventas", "VENTAS", "" },
                    { 4, "Index", "Contabilidad", "Modulo de libro diario, asientos, libro mayor.", true, "Contabilidad", "CONTABIL", "" },
                    { 5, "Index", "Produccion", "Modulo de producción, recetas, conversiones.", true, "Produccion", "PRODUCCI", "" }
                });

            migrationBuilder.InsertData(
                schema: "finanzas",
                table: "moneda",
                columns: new[] { "Id", "Nombre", "NombreCorto", "Prefix", "Simbolo", "Sufix" },
                values: new object[,]
                {
                    { 1, "SOLES", "PEN", "S/", "S/", "soles" },
                    { 2, "DÓLARES", "USD", "$", "$", "dólares" },
                    { 3, "EUROS", "EUR", "€", "€", "euros" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "pais",
                columns: new[] { "Id", "CodigoIso", "CodigoTelefono", "Nombre" },
                values: new object[,]
                {
                    { 1, "PE", "+51", "Perú" },
                    { 2, "US", "+1", "Estados Unidos" },
                    { 3, "MX", "+52", "México" },
                    { 4, "AR", "+54", "Argentina" },
                    { 5, "CL", "+56", "Chile" },
                    { 6, "CO", "+57", "Colombia" },
                    { 7, "ES", "+34", "España" },
                    { 8, "BR", "+55", "Brasil" },
                    { 9, "EC", "+593", "Ecuador" },
                    { 10, "CA", "+1", "Canadá" },
                    { 11, "FR", "+33", "Francia" },
                    { 12, "GB", "+44", "Reino Unido" },
                    { 13, "IT", "+39", "Italia" },
                    { 14, "DE", "+49", "Alemania" },
                    { 15, "JP", "+81", "Japón" },
                    { 16, "CN", "+86", "China" },
                    { 17, "IN", "+91", "India" },
                    { 18, "AU", "+61", "Australia" },
                    { 19, "ZA", "+27", "Sudáfrica" },
                    { 20, "NZ", "+64", "Nueva Zelanda" }
                });

            migrationBuilder.InsertData(
                schema: "rrhh",
                table: "personal_estado",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { (byte)1, "ACTIVO" },
                    { (byte)2, "RENUNCIA" },
                    { (byte)3, "DESPEDIDO" },
                    { (byte)4, "ABANDONO" },
                    { (byte)5, "SUSPENDIDO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "sexo",
                columns: new[] { "Id", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { (byte)1, "Masculino", "M" },
                    { (byte)2, "Femenino", "F" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "aplicacion-home", "true", "1" },
                    { 2, "aplicacion-formulario", "true", "1" },
                    { 3, "seguridad-rol", "true", "1" },
                    { 4, "seguridad-rol-usuario", "true", "1" },
                    { 5, "seguridad-rol-formulario", "true", "1" },
                    { 6, "seguridad-usuario", "true", "1" },
                    { 7, "aplicacion-home", "true", "2" },
                    { 8, "aplicacion-formulario", "true", "2" },
                    { 9, "seguridad-rol", "true", "2" },
                    { 10, "seguridad-rol-usuario", "true", "2" },
                    { 11, "seguridad-rol-formulario", "true", "2" },
                    { 12, "seguridad-usuario", "true", "2" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "departamento",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Amazonas", 1 },
                    { 2, "Áncash", 1 },
                    { 3, "Apurímac", 1 },
                    { 4, "Arequipa", 1 },
                    { 5, "Ayacucho", 1 },
                    { 6, "Cajamarca", 1 },
                    { 7, "Callao", 1 },
                    { 8, "Cusco", 1 },
                    { 9, "Huancavelica", 1 },
                    { 10, "Huánuco", 1 },
                    { 11, "Ica", 1 },
                    { 12, "Junín", 1 },
                    { 13, "La Libertad", 1 },
                    { 14, "Lambayeque", 1 },
                    { 15, "Lima", 1 },
                    { 16, "Loreto", 1 },
                    { 17, "Madre de Dios", 1 },
                    { 18, "Moquegua", 1 },
                    { 19, "Pasco", 1 },
                    { 20, "Piura", 1 },
                    { 21, "Puno", 1 },
                    { 22, "San Martín", 1 },
                    { 23, "Tacna", 1 },
                    { 24, "Tumbes", 1 },
                    { 25, "Ucayali", 1 }
                });

            migrationBuilder.InsertData(
                schema: "aplicacion",
                table: "formulario",
                columns: new[] { "Id", "Action", "ClaimType", "Controlador", "Descripcion", "Estado", "Icono", "ModuloId", "Nombre", "NombreCorto", "Orden", "ParentId" },
                values: new object[,]
                {
                    { 1, "Index", "aplicacion-home", "Seguridad", "", true, "home", 1, "Inicio", "INICIO", (short)1, null },
                    { 2, "", null, "", "", true, "window-restore", 1, "Aplicacion", "APLICACIO", (short)2, null },
                    { 4, "", null, "", "", true, "shield", 1, "Seguridad", "SEGURIDAD", (short)3, null },
                    { 3, "Formulario", "aplicacion-formulario", "Seguridad", "", true, "table-list", 1, "Formulario", "FORMULARI", (short)2, 2 },
                    { 5, "Rol", "seguridad-rol", "Seguridad", "", true, "users", 1, "Rol", "ROL", (short)1, 4 },
                    { 6, "RolUsuario", "seguridad-rol-usuario", "Seguridad", "", true, "users", 1, "Rol Usuarios", "ROLUSER", (short)2, 4 },
                    { 7, "RolFormulario", "seguridad-rol-formulario", "Seguridad", "", true, "users", 1, "Rol Formularios", "ROLFORM", (short)3, 4 },
                    { 8, "Usuario", "seguridad-usuario", "Seguridad", "", true, "users", 1, "Usuarios", "USER", (short)4, 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "provincia",
                columns: new[] { "Id", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 4, "Arequipa" },
                    { 2, 4, "Camaná" },
                    { 3, 4, "Caravelí" },
                    { 4, 4, "Castilla" },
                    { 5, 4, "Caylloma" },
                    { 6, 4, "Condesuyos" },
                    { 7, 4, "Islay" },
                    { 8, 4, "La Unión" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "distrito",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "Arequipa", 1 },
                    { 2, "Alto Selva Alegre", 1 },
                    { 3, "Cayma", 1 },
                    { 4, "Characato", 1 },
                    { 5, "Chiguata", 1 },
                    { 6, "Jacobo Hunter", 1 },
                    { 7, "La Joya", 1 },
                    { 8, "Miraflores", 1 },
                    { 9, "Mollebaya", 1 },
                    { 10, "Sabandía", 1 },
                    { 11, "San Juan de Siguas", 1 },
                    { 12, "San Juan de Tarucani", 1 },
                    { 13, "Santa Isabel de Siguas", 1 },
                    { 14, "Santa Rita de Siguas", 1 },
                    { 15, "Sachaca", 1 },
                    { 16, "Simón Bolívar", 1 },
                    { 17, "Tiabaya", 1 },
                    { 18, "Yanahuara", 1 },
                    { 19, "Cerro Colorado", 1 },
                    { 20, "Quequeña", 1 },
                    { 21, "Yura", 1 },
                    { 22, "Socabaya", 1 },
                    { 23, "Polobaya", 1 },
                    { 24, "Vitor", 1 },
                    { 25, "La Unión", 1 },
                    { 26, "Santa Teresa", 1 },
                    { 27, "Aplao", 1 },
                    { 28, "Chivay", 1 },
                    { 29, "Ichuña", 1 },
                    { 30, "Macate", 1 },
                    { 31, "Huambo", 1 },
                    { 32, "Orcopampa", 1 },
                    { 33, "Chivay", 1 }
                });

            migrationBuilder.InsertData(
                schema: "logistica",
                table: "almacen",
                columns: new[] { "Id", "Activo", "Direccion", "DistritoId", "Latitud", "Longitud", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { 1, true, "Av. Default 1", 1, 0m, 0m, "DEFAULT 1", "DEFAULT1" },
                    { 2, true, "Av. Default 2", 1, 0m, 0m, "DEFAULT 2", "DEFAULT2" },
                    { 3, true, "Av. Default 3", 1, 0m, 0m, "DEFAULT 3", "DEFAULT3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_activo_CentroDeCostosId",
                schema: "patrimonial",
                table: "activo",
                column: "CentroDeCostosId");

            migrationBuilder.CreateIndex(
                name: "IX_activo_ProductoLoteId",
                schema: "patrimonial",
                table: "activo",
                column: "ProductoLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_activo_TerceroId",
                schema: "patrimonial",
                table: "activo",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_activo_audit_Id",
                schema: "patrimonial",
                table: "activo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_almacen_DistritoId",
                schema: "logistica",
                table: "almacen",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_almacen_audit_Id",
                schema: "logistica",
                table: "almacen_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "security",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_audit_Id",
                schema: "security",
                table: "AspNetRoleClaims_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "security",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_audit_Id",
                schema: "security",
                table: "AspNetRoles_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "security",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_audit_Id",
                schema: "security",
                table: "AspNetUserClaims_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "security",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_audit_LoginProvider_ProviderKey",
                schema: "security",
                table: "AspNetUserLogins_audit",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "security",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_audit_UserId_RoleId",
                schema: "security",
                table: "AspNetUserRoles_audit",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "security",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "security",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_audit_Id",
                schema: "security",
                table: "AspNetUsers_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_audit_UserId_LoginProvider_Name",
                schema: "security",
                table: "AspNetUserTokens_audit",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_cargo_audit_Id",
                schema: "rrhh",
                table: "cargo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_centro_de_costos_PadreId",
                schema: "costos",
                table: "centro_de_costos",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_centro_de_costos_audit_Id",
                schema: "costos",
                table: "centro_de_costos_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_cabecera_ContratoTipoId_Numero",
                schema: "legal",
                table: "contrato_cabecera",
                columns: new[] { "ContratoTipoId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contrato_cabecera_audit_Id",
                schema: "legal",
                table: "contrato_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_detalle_ContratoCabeceraId_PersonaId",
                schema: "legal",
                table: "contrato_detalle",
                columns: new[] { "ContratoCabeceraId", "PersonaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contrato_detalle_PersonaId",
                schema: "legal",
                table: "contrato_detalle",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_detalle_audit_Id",
                schema: "legal",
                table: "contrato_detalle_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_personal_CargoId",
                schema: "legal",
                table: "contrato_personal",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_personal_EstructuraOrganizacionalId",
                schema: "legal",
                table: "contrato_personal",
                column: "EstructuraOrganizacionalId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_personal_PersonaId",
                schema: "legal",
                table: "contrato_personal",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_personal_audit_ContratoCabeceraId",
                schema: "legal",
                table: "contrato_personal_audit",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_tipo_audit_Id",
                schema: "legal",
                table: "contrato_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_contable_CuentaContableTipoId",
                schema: "contabilidad",
                table: "cuenta_contable",
                column: "CuentaContableTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_contable_PadreId",
                schema: "contabilidad",
                table: "cuenta_contable",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_contable_audit_Id",
                schema: "contabilidad",
                table: "cuenta_contable_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_contable_tipo_audit_Id",
                schema: "contabilidad",
                table: "cuenta_contable_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_corriente_CuentaContableId",
                schema: "finanzas",
                table: "cuenta_corriente",
                column: "CuentaContableId");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_corriente_EntidadFinancieraId",
                schema: "finanzas",
                table: "cuenta_corriente",
                column: "EntidadFinancieraId");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_corriente_audit_Id",
                schema: "finanzas",
                table: "cuenta_corriente_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_PaisId",
                schema: "dbo",
                table: "departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_audit_Id",
                schema: "dbo",
                table: "departamento_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_distrito_ProvinciaId",
                schema: "dbo",
                table: "distrito",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_distrito_audit_Id",
                schema: "dbo",
                table: "distrito_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_documento_identidad_tipo_audit_Id",
                schema: "dbo",
                table: "documento_identidad_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_documento_tipo_audit_Id",
                schema: "dbo",
                table: "documento_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_entidad_financiera_audit_Id",
                schema: "finanzas",
                table: "entidad_financiera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_estructura_organizacional_EstructuraOrganizacionalTipoId",
                schema: "organizacion",
                table: "estructura_organizacional",
                column: "EstructuraOrganizacionalTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_estructura_organizacional_ParentId",
                schema: "organizacion",
                table: "estructura_organizacional",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_estructura_organizacional_audit_Id",
                schema: "organizacion",
                table: "estructura_organizacional_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_estructura_organizacional_tipo_audit_Id",
                schema: "organizacion",
                table: "estructura_organizacional_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_cabecera_DocumentoTipoGenId",
                schema: "finanzas",
                table: "financiero_cabecera",
                column: "DocumentoTipoGenId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_cabecera_OrigenFinancieroId",
                schema: "finanzas",
                table: "financiero_cabecera",
                column: "OrigenFinancieroId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_cabecera_PuntoFinancieroId",
                schema: "finanzas",
                table: "financiero_cabecera",
                column: "PuntoFinancieroId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_cabecera_TerceroGenId",
                schema: "finanzas",
                table: "financiero_cabecera",
                column: "TerceroGenId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_cabecera_audit_Id",
                schema: "finanzas",
                table: "financiero_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_detalle_CuentaCorrienteId",
                schema: "finanzas",
                table: "financiero_detalle",
                column: "CuentaCorrienteId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_detalle_DocumentoTipoId",
                schema: "finanzas",
                table: "financiero_detalle",
                column: "DocumentoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_detalle_FinancieroCabeceraId",
                schema: "finanzas",
                table: "financiero_detalle",
                column: "FinancieroCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_detalle_TerceroId",
                schema: "finanzas",
                table: "financiero_detalle",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_detalle_audit_Id",
                schema: "finanzas",
                table: "financiero_detalle_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_logistica_FinancieroDetalleId_InventarioCabeceraId",
                schema: "finanzas",
                table: "financiero_logistica",
                columns: new[] { "FinancieroDetalleId", "InventarioCabeceraId" });

            migrationBuilder.CreateIndex(
                name: "IX_financiero_logistica_InventarioCabeceraId",
                schema: "finanzas",
                table: "financiero_logistica",
                column: "InventarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_logistica_audit_Id",
                schema: "finanzas",
                table: "financiero_logistica_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_orden_servicio_FinancieroDetalleId_OrdenServicioC~",
                schema: "finanzas",
                table: "financiero_orden_servicio",
                columns: new[] { "FinancieroDetalleId", "OrdenServicioCabeceraId" });

            migrationBuilder.CreateIndex(
                name: "IX_financiero_orden_servicio_OrdenServicioCabeceraId",
                schema: "finanzas",
                table: "financiero_orden_servicio",
                column: "OrdenServicioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_financiero_orden_servicio_audit_Id",
                schema: "finanzas",
                table: "financiero_orden_servicio_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_formulario_ClaimType",
                schema: "aplicacion",
                table: "formulario",
                column: "ClaimType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_formulario_ModuloId",
                schema: "aplicacion",
                table: "formulario",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_formulario_ParentId",
                schema: "aplicacion",
                table: "formulario",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_formulario_audit_Id",
                schema: "aplicacion",
                table: "formulario_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_horario_audit_Id",
                schema: "rrhh",
                table: "grupo_horario_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_audit_Id",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                column: "GrupoTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_PersonaId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_audit_Id",
                schema: "rrhh",
                table: "grupo_trabajo_persona_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_horario_cabecera_audit_Id",
                schema: "rrhh",
                table: "horario_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_horario_detalle_GrupoHorarioId",
                schema: "rrhh",
                table: "horario_detalle",
                column: "GrupoHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_horario_detalle_HorarioCabeceraId",
                schema: "rrhh",
                table: "horario_detalle",
                column: "HorarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_horario_detalle_audit_Id",
                schema: "rrhh",
                table: "horario_detalle_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_cabecera_AlmacenId",
                schema: "logistica",
                table: "inventario_cabecera",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_cabecera_DocumentoTipoId",
                schema: "logistica",
                table: "inventario_cabecera",
                column: "DocumentoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_cabecera_LogisticaTransaccionId",
                schema: "logistica",
                table: "inventario_cabecera",
                column: "LogisticaTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_cabecera_audit_Id",
                schema: "logistica",
                table: "inventario_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_detalle_InventarioCabeceraId",
                schema: "logistica",
                table: "inventario_detalle",
                column: "InventarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_detalle_ProductoId",
                schema: "logistica",
                table: "inventario_detalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_detalle_ProductoLoteId",
                schema: "logistica",
                table: "inventario_detalle",
                column: "ProductoLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_detalle_audit_Id",
                schema: "logistica",
                table: "inventario_detalle_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_labor_audit_Id",
                schema: "mantto",
                table: "labor_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_licencia_conducir_audit_Id",
                schema: "dbo",
                table: "licencia_conducir_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_logistica_transaccion_audit_Id",
                schema: "logistica",
                table: "logistica_transaccion_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimiento_tipo_audit_Id",
                schema: "mantto",
                table: "mantenimiento_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_modulo_audit_Id",
                schema: "aplicacion",
                table: "modulo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_moneda_audit_Id",
                schema: "finanzas",
                table: "moneda_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_cabecera_OrdenServicioTipoId",
                schema: "mantto",
                table: "orden_servicio_cabecera",
                column: "OrdenServicioTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_cabecera_audit_Id",
                schema: "mantto",
                table: "orden_servicio_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_ActaConformidadId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "ActaConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_ClienteId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_ClientePlannerId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "ClientePlannerId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_ClienteSupervisorId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "ClienteSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_ContratoCabeceraId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_MantenimientoTipoId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "MantenimientoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_MonedaId",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_mantenimiento_externo_audit_Id",
                schema: "mantto",
                table: "orden_servicio_mantenimiento_externo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_tipo_audit_Id",
                schema: "mantto",
                table: "orden_servicio_tipo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_cabecera_GrupoTrabajoId",
                schema: "mantto",
                table: "orden_trabajo_cabecera",
                column: "GrupoTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_cabecera_OrdenServicioCabeceraId",
                schema: "mantto",
                table: "orden_trabajo_cabecera",
                column: "OrdenServicioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_cabecera_OrdenTrabajoCabeceraPadreId",
                schema: "mantto",
                table: "orden_trabajo_cabecera",
                column: "OrdenTrabajoCabeceraPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_cabecera_audit_Id",
                schema: "mantto",
                table: "orden_trabajo_cabecera_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_LaborId",
                schema: "mantto",
                table: "orden_trabajo_detalle",
                column: "LaborId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_OrdenTrabajoCabeceraId",
                schema: "mantto",
                table: "orden_trabajo_detalle",
                column: "OrdenTrabajoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_UbicacionTecnicaId",
                schema: "mantto",
                table: "orden_trabajo_detalle",
                column: "UbicacionTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_activo_ActivoId",
                schema: "mantto",
                table: "orden_trabajo_detalle_activo",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_activo_audit_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle_activo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_detalle_audit_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_personal_OrdenTrabajoCabeceraId",
                schema: "mantto",
                table: "orden_trabajo_personal",
                column: "OrdenTrabajoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_personal_PersonaId",
                schema: "mantto",
                table: "orden_trabajo_personal",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_trabajo_personal_audit_Id",
                schema: "mantto",
                table: "orden_trabajo_personal_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_origen_financiero_audit_Id",
                schema: "finanzas",
                table: "origen_financiero_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_pais_audit_Id",
                schema: "dbo",
                table: "pais_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_persona_DistritoId",
                schema: "dbo",
                table: "persona",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_DocumentoIdentidadTipoId",
                schema: "dbo",
                table: "persona",
                column: "DocumentoIdentidadTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_LicenciaConducirId",
                schema: "dbo",
                table: "persona",
                column: "LicenciaConducirId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_SexoId",
                schema: "dbo",
                table: "persona",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_audit_Id",
                schema: "dbo",
                table: "persona_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_ContratoCabeceraId",
                schema: "rrhh",
                table: "personal",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_HorarioCabeceraId",
                schema: "rrhh",
                table: "personal",
                column: "HorarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_PersonalEstadoId",
                schema: "rrhh",
                table: "personal",
                column: "PersonalEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_SuperiorId",
                schema: "rrhh",
                table: "personal",
                column: "SuperiorId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_audit_Id",
                schema: "rrhh",
                table: "personal_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_estado_audit_Id",
                schema: "rrhh",
                table: "personal_estado_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_producto_UnidadMedidaCompraId",
                schema: "logistica",
                table: "producto",
                column: "UnidadMedidaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_UnidadMedidaConsumoId",
                schema: "logistica",
                table: "producto",
                column: "UnidadMedidaConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_audit_Id",
                schema: "logistica",
                table: "producto_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_producto_lote_MonedaId",
                schema: "logistica",
                table: "producto_lote",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_lote_ProductoId",
                schema: "logistica",
                table: "producto_lote",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_lote_audit_Id",
                schema: "logistica",
                table: "producto_lote_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_provincia_DepartamentoId",
                schema: "dbo",
                table: "provincia",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_provincia_audit_Id",
                schema: "dbo",
                table: "provincia_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_punto_financiero_audit_Id",
                schema: "finanzas",
                table: "punto_financiero_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_sexo_audit_Id",
                schema: "dbo",
                table: "sexo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_CuentaContablePorCobrarId",
                schema: "finanzas",
                table: "tercero",
                column: "CuentaContablePorCobrarId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_CuentaContablePorPagarId",
                schema: "finanzas",
                table: "tercero",
                column: "CuentaContablePorPagarId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_DocumentoIdentidadTipoFinancieroId",
                schema: "finanzas",
                table: "tercero",
                column: "DocumentoIdentidadTipoFinancieroId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_audit_Id",
                schema: "finanzas",
                table: "tercero_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_activo_ActivoId",
                schema: "patrimonial",
                table: "ubicacion_activo",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_activo_ContratoCabeceraId",
                schema: "patrimonial",
                table: "ubicacion_activo",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_activo_UbicacionTecnicaId",
                schema: "patrimonial",
                table: "ubicacion_activo",
                column: "UbicacionTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_activo_audit_Id",
                schema: "patrimonial",
                table: "ubicacion_activo_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_tecnica_PadreId",
                schema: "patrimonial",
                table: "ubicacion_tecnica",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_tecnica_TerceroId",
                schema: "patrimonial",
                table: "ubicacion_tecnica",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_ubicacion_tecnica_audit_Id",
                schema: "patrimonial",
                table: "ubicacion_tecnica_audit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_unidad_medida_audit_Id",
                schema: "logistica",
                table: "unidad_medida_audit",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activo_audit",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "almacen_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetRoles_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUsers_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens_audit",
                schema: "security");

            migrationBuilder.DropTable(
                name: "cargo_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "centro_de_costos_audit",
                schema: "costos");

            migrationBuilder.DropTable(
                name: "contrato_cabecera_audit",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "contrato_detalle",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "contrato_detalle_audit",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "contrato_personal",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "contrato_personal_audit",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "contrato_tipo_audit",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "correlativo_maestro",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "cuenta_contable_audit",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "cuenta_contable_tipo_audit",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "cuenta_corriente_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "departamento_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "distrito_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "documento_identidad_tipo_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "documento_tipo_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "entidad_financiera_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "estructura_organizacional_audit",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "estructura_organizacional_tipo_audit",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "financiero_cabecera_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_detalle_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_logistica",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_logistica_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_orden_servicio",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_orden_servicio_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "formulario",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "formulario_audit",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "grupo_horario_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "grupo_trabajo_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "grupo_trabajo_persona",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "grupo_trabajo_persona_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "horario_cabecera_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "horario_detalle",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "horario_detalle_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "inventario_cabecera_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "inventario_detalle",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "inventario_detalle_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "labor_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "licencia_conducir_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "logistica_transaccion_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "mantenimiento_tipo_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "modulo_audit",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "moneda_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "orden_servicio_cabecera_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_servicio_mantenimiento_externo",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_servicio_mantenimiento_externo_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_servicio_tipo_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_cabecera_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_detalle_activo",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_detalle_activo_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_detalle_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_personal",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_personal_audit",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "origen_financiero_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "pais_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "persona_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "personal",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "personal_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "personal_estado_audit",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "producto_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "producto_lote_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "provincia_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "punto_financiero_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "sexo_audit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tercero_audit",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "ubicacion_activo",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "ubicacion_activo_audit",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "ubicacion_tecnica_audit",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "unidad_medida_audit",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "security");

            migrationBuilder.DropTable(
                name: "cargo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "estructura_organizacional",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "financiero_detalle",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "modulo",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "grupo_horario",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "inventario_cabecera",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "mantenimiento_tipo",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_detalle",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "horario_cabecera",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "personal_estado",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "activo",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "contrato_cabecera",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "estructura_organizacional_tipo",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "cuenta_corriente",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "financiero_cabecera",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "almacen",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "logistica_transaccion",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "labor",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "orden_trabajo_cabecera",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "ubicacion_tecnica",
                schema: "patrimonial");

            migrationBuilder.DropTable(
                name: "centro_de_costos",
                schema: "costos");

            migrationBuilder.DropTable(
                name: "producto_lote",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "contrato_tipo",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "entidad_financiera",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "documento_tipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "origen_financiero",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "punto_financiero",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "grupo_trabajo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "orden_servicio_cabecera",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "tercero",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "moneda",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "producto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "orden_servicio_tipo",
                schema: "mantto");

            migrationBuilder.DropTable(
                name: "cuenta_contable",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "persona",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "unidad_medida",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "cuenta_contable_tipo",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "distrito",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "documento_identidad_tipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licencia_conducir",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sexo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "provincia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "departamento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "pais",
                schema: "dbo");
        }
    }
}
