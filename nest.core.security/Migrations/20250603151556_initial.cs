using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nest.core.security.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "logistica");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.EnsureSchema(
                name: "rrhh");

            migrationBuilder.EnsureSchema(
                name: "legal");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "organizacion");

            migrationBuilder.EnsureSchema(
                name: "aplicacion");

            migrationBuilder.EnsureSchema(
                name: "finanzas");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "audit_log",
                schema: "audit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EntidadNombre = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    EntidadId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit_log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contrato_tipo",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documento_identidad_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_identidad_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documento_tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    CodigoEstatal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estructura_organizacional_tipo",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estructura_organizacional_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grupo_horario",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    HoraEntrada = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraSalida = table.Column<TimeOnly>(type: "time", nullable: false),
                    DiferenciaDia = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_horario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "horario_cabecera",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario_cabecera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "licencia_conducir",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nivel = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licencia_conducir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "logistica_transaccion",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    ES = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistica_transaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modulo",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    RutaImagen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Controlador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moneda",
                schema: "finanzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Sufix = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Simbolo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pais",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CodigoIso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CodigoTelefono = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sexo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidad_medida",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad_medida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "estructura_organizacional",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    EstructuraOrganizacionalTipoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Final = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                        name: "FK_estructura_organizacional_estructura_organizacional_tipo_EstructuraOrganizacionalTipoId",
                        column: x => x.EstructuraOrganizacionalTipoId,
                        principalSchema: "organizacion",
                        principalTable: "estructura_organizacional_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "horario_detalle",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<byte>(type: "tinyint", nullable: false),
                    GrupoHorarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "formulario",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    Controlador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Orden = table.Column<short>(type: "smallint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "persona",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    SexoId = table.Column<byte>(type: "tinyint", nullable: false),
                    LicenciaConducirId = table.Column<byte>(type: "tinyint", nullable: true),
                    DocumentoIdentidadTipoId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "producto",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    UnidadMedidaCompraId = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaConsumoId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    PuedeGenerarNuevosLotes = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "provincia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "producto_lote",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    SerialId = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "distrito",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "almacen",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "inventario_cabecera",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    LogisticaTransaccionId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoTipoId = table.Column<int>(type: "int", nullable: false),
                    DocumentoSerie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DocumentoNumero = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true)
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
                        name: "FK_inventario_cabecera_logistica_transaccion_LogisticaTransaccionId",
                        column: x => x.LogisticaTransaccionId,
                        principalSchema: "logistica",
                        principalTable: "logistica_transaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Nota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "contrato_cabecera",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ContratoTipoId = table.Column<byte>(type: "tinyint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Resumen = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "contrato_detalle",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ContratoCabeceraId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    FechaUltimaNotificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Firmo = table.Column<bool>(type: "bit", nullable: false),
                    FechaFirma = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "personal_configuracion",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ContratoCabeceraId = table.Column<int>(type: "int", nullable: false),
                    MarcaAsistencia = table.Column<bool>(type: "bit", nullable: false),
                    HorarioCabeceraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_configuracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_configuracion_contrato_cabecera_ContratoCabeceraId",
                        column: x => x.ContratoCabeceraId,
                        principalSchema: "legal",
                        principalTable: "contrato_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personal_configuracion_horario_cabecera_HorarioCabeceraId",
                        column: x => x.HorarioCabeceraId,
                        principalSchema: "rrhh",
                        principalTable: "horario_cabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_personal_configuracion_Id",
                        column: x => x.Id,
                        principalSchema: "rrhh",
                        principalTable: "personal_configuracion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contrato_personal",
                schema: "legal",
                columns: table => new
                {
                    ContratoCabeceraId = table.Column<int>(type: "int", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_contrato_personal_estructura_organizacional_EstructuraOrganizacionalId",
                        column: x => x.EstructuraOrganizacionalId,
                        principalSchema: "organizacion",
                        principalTable: "estructura_organizacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contrato_personal_personal_PersonalId",
                        column: x => x.PersonalId,
                        principalSchema: "rrhh",
                        principalTable: "personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { "1", 0, "e2246c99-4fc1-4d44-86db-e74a3b21328f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDf5JhM1AlW1FSl22nP5+5njvIghZ+4q0lyykHT7mv5WJU227Kz2sAMX6lB6vLoU+g==", null, false, "83db95b0-bec8-44fe-8cbf-aa21a14bfa15", false, "admin@admin.com" },
                    { "2", 0, "2c331185-26c4-49d5-b12f-46476c4d73aa", "superadmin@admin.com", true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDaapBoXljApwrj66TY0g1VN/KNQoOrQ18lY9cYihine2rjx/OCIGMDtuTxoH9GIBw==", null, false, "922d8332-1c75-4210-8709-2d47487e9bbc", false, "superadmin@admin.com" }
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
                columns: new[] { "Id", "Action", "Controlador", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "NombreCorto", "RutaImagen" },
                values: new object[,]
                {
                    { 1, "Index", "Seguridad", "Modulo donde se setean los roles, permisos y menús.", true, new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(4989), new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(4993), "Seguridad", "SECURITY", "" },
                    { 2, "Index", "Logistica", "Modulo de inventarios logistica y transferencias.", true, new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5762), new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5763), "Logistica", "LOGISTIC", "" },
                    { 3, "Index", "VentasHome", "Modulo de facturacion, ventas, caja.", true, new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5765), new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5765), "Ventas", "VENTAS", "" },
                    { 4, "Index", "Contabilidad", "Modulo de libro diario, asientos, libro mayor.", true, new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5767), new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5767), "Contabilidad", "CONTABIL", "" },
                    { 5, "Index", "Produccion", "Modulo de producción, recetas, conversiones.", true, new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5768), new DateTime(2025, 6, 3, 10, 15, 55, 607, DateTimeKind.Local).AddTicks(5769), "Produccion", "PRODUCCI", "" }
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
                columns: new[] { "Id", "Action", "ClaimType", "Controlador", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Icono", "ModuloId", "Nombre", "NombreCorto", "Orden", "ParentId" },
                values: new object[,]
                {
                    { 1, "Index", "aplicacion-home", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 604, DateTimeKind.Local).AddTicks(8311), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(1935), "home", 1, "Inicio", "INICIO", (short)1, null },
                    { 2, "", null, "", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3500), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3501), "window-restore", 1, "Aplicacion", "APLICACIO", (short)2, null },
                    { 4, "", null, "", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3510), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3510), "shield", 1, "Seguridad", "SEGURIDAD", (short)3, null },
                    { 3, "Formulario", "aplicacion-formulario", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3505), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3506), "table-list", 1, "Formulario", "FORMULARI", (short)2, 2 },
                    { 5, "Rol", "seguridad-rol", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3512), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3513), "users", 1, "Rol", "ROL", (short)1, 4 },
                    { 6, "RolUsuario", "seguridad-rol-usuario", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3531), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3531), "users", 1, "Rol Usuarios", "ROLUSER", (short)2, 4 },
                    { 7, "RolFormulario", "seguridad-rol-formulario", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3533), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3534), "users", 1, "Rol Formularios", "ROLFORM", (short)3, 4 },
                    { 8, "Usuario", "seguridad-usuario", "Seguridad", "", true, new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3535), new DateTime(2025, 6, 3, 10, 15, 55, 606, DateTimeKind.Local).AddTicks(3536), "users", 1, "Usuarios", "USER", (short)4, 4 }
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
                name: "IX_almacen_DistritoId",
                schema: "logistica",
                table: "almacen",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "security",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "security",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "security",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "security",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "security",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_cabecera_ContratoTipoId_Numero",
                schema: "legal",
                table: "contrato_cabecera",
                columns: new[] { "ContratoTipoId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contrato_detalle_ContratoCabeceraId",
                schema: "legal",
                table: "contrato_detalle",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_detalle_PersonaId",
                schema: "legal",
                table: "contrato_detalle",
                column: "PersonaId");

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
                name: "IX_contrato_personal_PersonalId",
                schema: "legal",
                table: "contrato_personal",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_PaisId",
                schema: "dbo",
                table: "departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_distrito_ProvinciaId",
                schema: "dbo",
                table: "distrito",
                column: "ProvinciaId");

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
                name: "IX_formulario_ClaimType",
                schema: "aplicacion",
                table: "formulario",
                column: "ClaimType",
                unique: true,
                filter: "[ClaimType] IS NOT NULL");

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
                name: "IX_personal_configuracion_ContratoCabeceraId",
                schema: "rrhh",
                table: "personal_configuracion",
                column: "ContratoCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_configuracion_HorarioCabeceraId",
                schema: "rrhh",
                table: "personal_configuracion",
                column: "HorarioCabeceraId");

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
                name: "IX_provincia_DepartamentoId",
                schema: "dbo",
                table: "provincia",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_contrato_cabecera_contrato_personal_Id",
                schema: "legal",
                table: "contrato_cabecera",
                column: "Id",
                principalSchema: "legal",
                principalTable: "contrato_personal",
                principalColumn: "ContratoCabeceraId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrato_cabecera_contrato_personal_Id",
                schema: "legal",
                table: "contrato_cabecera");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "security");

            migrationBuilder.DropTable(
                name: "audit_log",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "contrato_detalle",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "formulario",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "horario_detalle",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "inventario_detalle",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "security");

            migrationBuilder.DropTable(
                name: "persona",
                schema: "dbo");

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
                name: "producto_lote",
                schema: "logistica");

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
                name: "almacen",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "documento_tipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "logistica_transaccion",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "moneda",
                schema: "finanzas");

            migrationBuilder.DropTable(
                name: "producto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "distrito",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "unidad_medida",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "provincia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "departamento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "pais",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "contrato_personal",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "cargo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "estructura_organizacional",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "personal",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "estructura_organizacional_tipo",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "personal_configuracion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "contrato_cabecera",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "horario_cabecera",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "contrato_tipo",
                schema: "legal");
        }
    }
}
