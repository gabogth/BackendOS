using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nest.core.security.Migrations
{
    /// <inheritdoc />
    public partial class personal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rrhh");

            migrationBuilder.EnsureSchema(
                name: "legal");

            migrationBuilder.CreateTable(
                name: "cargo",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contratotipo",
                schema: "legal",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratotipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documentoidentidadtipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NombreCorto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentoidentidadtipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "licenciaconducir",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nivel = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licenciaconducir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personal",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    SexoId = table.Column<byte>(type: "tinyint", nullable: false),
                    LicenciaConducirId = table.Column<byte>(type: "tinyint", nullable: false),
                    DocumentoIdentidadTipoId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personal_documentoidentidadtipo_DocumentoIdentidadTipoId",
                        column: x => x.DocumentoIdentidadTipoId,
                        principalSchema: "dbo",
                        principalTable: "documentoidentidadtipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personal_licenciaconducir_LicenciaConducirId",
                        column: x => x.LicenciaConducirId,
                        principalSchema: "rrhh",
                        principalTable: "licenciaconducir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb579973-2a3e-4eef-8c32-f23629dbacc7", "AQAAAAIAAYagAAAAEEP7GeMIQjgKRMzrpTrle2LmPp6e7+Izdl+rIg+BxUgDYNE/YMdc9gvGFmDQ6Uldqg==", "0ca69a2d-ae71-4922-8cf4-1f113688f20d" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d1cd288-bc99-486b-b14a-642689b642b6", "AQAAAAIAAYagAAAAEPUjoxw2vTdMMWG3TA5785/6Z/PmTuC9UCXnW1NvpoANuCqBqMZGAh60h9xq4G/64A==", "c30d420e-5db5-4d9d-835c-7e20945bd465" });

            migrationBuilder.InsertData(
                table: "Sexo",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { (byte)1, "Hombre" },
                    { (byte)2, "Mujer" },
                    { (byte)3, "Otros" }
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
                table: "contratotipo",
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
                table: "documentoidentidadtipo",
                columns: new[] { "Id", "Nombre", "NombreCorto" },
                values: new object[,]
                {
                    { (byte)1, "Documento nacional de identidad", "DNI" },
                    { (byte)2, "Carnet de extranjería", "CE" },
                    { (byte)3, "Pasaporte", "PSX" },
                    { (byte)4, "Permiso temporal de permanencia", "PTP" }
                });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 334, DateTimeKind.Local).AddTicks(2926), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(3947) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5473), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5479), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5483) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5485), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5491), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5492) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5493), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5496), new DateTime(2024, 12, 18, 11, 38, 48, 335, DateTimeKind.Local).AddTicks(5496) });

            migrationBuilder.InsertData(
                schema: "rrhh",
                table: "licenciaconducir",
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
                    { (byte)8, (byte)7, "BIIA" },
                    { (byte)9, (byte)7, "BIIB" }
                });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(4252), new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(4256) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5238), new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5241) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5243), new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5245), new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5246) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5247), new DateTime(2024, 12, 18, 11, 38, 48, 336, DateTimeKind.Local).AddTicks(5247) });

            migrationBuilder.CreateIndex(
                name: "IX_personal_DocumentoIdentidadTipoId",
                schema: "rrhh",
                table: "personal",
                column: "DocumentoIdentidadTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_LicenciaConducirId",
                schema: "rrhh",
                table: "personal",
                column: "LicenciaConducirId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_SexoId",
                schema: "rrhh",
                table: "personal",
                column: "SexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargo",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "contratotipo",
                schema: "legal");

            migrationBuilder.DropTable(
                name: "personal",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "documentoidentidadtipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licenciaconducir",
                schema: "rrhh");

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82ce97eb-3029-4536-aaf3-179216f3f1ea", "AQAAAAIAAYagAAAAEDVezeuXs2XqhPUSgGiOsIYM4SCNZNB2q+iIlxjIOI+Qg2kiz4cJiGepq5SIe5oR7A==", "ac780e52-1e95-4cb2-9079-d9a4932983cb" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca20bfbf-a106-4b5a-b3c5-5edf345e04db", "AQAAAAIAAYagAAAAEMA0TxImnMk4nP/IPL3RgXrVK1S63phpYNtdnxnN1R6qvj4NS/7r+ijr9gNZpGDcsQ==", "327416fb-c0ab-426c-91b1-db1c87c16c5e" });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 61, DateTimeKind.Local).AddTicks(5932), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8514), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8519), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8519) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8522), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8523) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8524), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8525) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8532), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8535) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8537), new DateTime(2024, 11, 22, 9, 49, 16, 62, DateTimeKind.Local).AddTicks(8537) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(7845), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(7850) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8711), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8711) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8714), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8714) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8716), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8718), new DateTime(2024, 11, 22, 9, 49, 16, 63, DateTimeKind.Local).AddTicks(8718) });
        }
    }
}
