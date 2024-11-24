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
                name: "dbo");

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
                name: "auditlog",
                schema: "audit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_auditlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documentotipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    CodigoEstatal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentotipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "logisticatransaccion",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    ES = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logisticatransaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modulo",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CodigoIso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CodigoTelefono = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidadmedida",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadmedida", x => x.Id);
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
                name: "formulario",
                schema: "aplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_producto_unidadmedida_UnidadMedidaCompraId",
                        column: x => x.UnidadMedidaCompraId,
                        principalSchema: "logistica",
                        principalTable: "unidadmedida",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_producto_unidadmedida_UnidadMedidaConsumoId",
                        column: x => x.UnidadMedidaConsumoId,
                        principalSchema: "logistica",
                        principalTable: "unidadmedida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "provincia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productolote",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_productolote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productolote_moneda_MonedaId",
                        column: x => x.MonedaId,
                        principalSchema: "finanzas",
                        principalTable: "moneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productolote_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "logistica",
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "distrito",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "almacen",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "inventariocabecera",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_inventariocabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventariocabecera_almacen_AlmacenId",
                        column: x => x.AlmacenId,
                        principalSchema: "logistica",
                        principalTable: "almacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventariocabecera_documentotipo_DocumentoTipoId",
                        column: x => x.DocumentoTipoId,
                        principalSchema: "dbo",
                        principalTable: "documentotipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventariocabecera_logisticatransaccion_LogisticaTransaccionId",
                        column: x => x.LogisticaTransaccionId,
                        principalSchema: "logistica",
                        principalTable: "logisticatransaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventariodetalle",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioCabeceraId = table.Column<long>(type: "bigint", nullable: false),
                    Item = table.Column<short>(type: "smallint", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductoLoteId = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventariodetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventariodetalle_inventariocabecera_InventarioCabeceraId",
                        column: x => x.InventarioCabeceraId,
                        principalSchema: "logistica",
                        principalTable: "inventariocabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventariodetalle_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "logistica",
                        principalTable: "producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventariodetalle_productolote_ProductoLoteId",
                        column: x => x.ProductoLoteId,
                        principalSchema: "logistica",
                        principalTable: "productolote",
                        principalColumn: "Id");
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
                    { "1", 0, "82ce97eb-3029-4536-aaf3-179216f3f1ea", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDVezeuXs2XqhPUSgGiOsIYM4SCNZNB2q+iIlxjIOI+Qg2kiz4cJiGepq5SIe5oR7A==", null, false, "ac780e52-1e95-4cb2-9079-d9a4932983cb", false, "admin@admin.com" },
                    { "2", 0, "ca20bfbf-a106-4b5a-b3c5-5edf345e04db", "superadmin@admin.com", true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMA0TxImnMk4nP/IPL3RgXrVK1S63phpYNtdnxnN1R6qvj4NS/7r+ijr9gNZpGDcsQ==", null, false, "327416fb-c0ab-426c-91b1-db1c87c16c5e", false, "superadmin@admin.com" }
                });

            migrationBuilder.InsertData(
                schema: "logistica",
                table: "logisticatransaccion",
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
                    { 1, "Index", "Seguridad", "Modulo donde se setean los roles, permisos y menús.", true, new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(7845), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(7850), "Seguridad", "SECURITY", "" },
                    { 2, "Index", "Logistica", "Modulo de inventarios logistica y transferencias.", true, new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8711), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8711), "Logistica", "LOGISTIC", "" },
                    { 3, "Index", "VentasHome", "Modulo de facturacion, ventas, caja.", true, new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8714), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8714), "Ventas", "VENTAS", "" },
                    { 4, "Index", "Contabilidad", "Modulo de libro diario, asientos, libro mayor.", true, new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8716), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8716), "Contabilidad", "CONTABIL", "" },
                    { 5, "Index", "Produccion", "Modulo de producción, recetas, conversiones.", true, new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8718), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8718), "Produccion", "PRODUCCI", "" }
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
                    { 1, "Index", "aplicacion-home", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 61, DateTimeKind.Local).AddTicks(5932), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(7052), "home", 1, "Inicio", "INICIO", (short)1, null },
                    { 2, "", null, "", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8514), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8515), "window-restore", 1, "Aplicacion", "APLICACIO", (short)2, null },
                    { 4, "", null, "", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8522), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8523), "shield", 1, "Seguridad", "SEGURIDAD", (short)3, null },
                    { 3, "Formulario", "aplicacion-formulario", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8519), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8519), "table-list", 1, "Formulario", "FORMULARI", (short)2, 2 },
                    { 5, "Rol", "seguridad-rol", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8524), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8525), "users", 1, "Rol", "ROL", (short)1, 4 },
                    { 6, "RolUsuario", "seguridad-rol-usuario", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8532), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8533), "users", 1, "Rol Usuarios", "ROLUSER", (short)2, 4 },
                    { 7, "RolFormulario", "seguridad-rol-formulario", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8535), "users", 1, "Rol Formularios", "ROLFORM", (short)3, 4 },
                    { 8, "Usuario", "seguridad-usuario", "Seguridad", "", true, new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8537), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8537), "users", 1, "Usuarios", "USER", (short)4, 4 }
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
                name: "IX_inventariocabecera_AlmacenId",
                schema: "logistica",
                table: "inventariocabecera",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_inventariocabecera_DocumentoTipoId",
                schema: "logistica",
                table: "inventariocabecera",
                column: "DocumentoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventariocabecera_LogisticaTransaccionId",
                schema: "logistica",
                table: "inventariocabecera",
                column: "LogisticaTransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle_InventarioCabeceraId",
                schema: "logistica",
                table: "inventariodetalle",
                column: "InventarioCabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle_ProductoId",
                schema: "logistica",
                table: "inventariodetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle_ProductoLoteId",
                schema: "logistica",
                table: "inventariodetalle",
                column: "ProductoLoteId");

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
                name: "IX_productolote_MonedaId",
                schema: "logistica",
                table: "productolote",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_productolote_ProductoId",
                schema: "logistica",
                table: "productolote",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_provincia_DepartamentoId",
                schema: "dbo",
                table: "provincia",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "auditlog",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "formulario",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "inventariodetalle",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "security");

            migrationBuilder.DropTable(
                name: "modulo",
                schema: "aplicacion");

            migrationBuilder.DropTable(
                name: "inventariocabecera",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "productolote",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "almacen",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "documentotipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "logisticatransaccion",
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
                name: "unidadmedida",
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
        }
    }
}
