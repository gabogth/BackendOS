using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.security.Migrations
{
    /// <inheritdoc />
    public partial class personal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93d75960-13ff-4aba-8dc7-46b1c5f6aa3e", "AQAAAAIAAYagAAAAEDPUrlwzkiIhdgUp55cpWy6wL7KD8x+1lhlAyf796OrYr8DLQSbSNho7PkOptPEm8g==", "973b3bbb-7c82-46fa-928a-641f8d808746" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "633cc906-04c1-4807-957d-18a4aeac7f16", "AQAAAAIAAYagAAAAEItzNbFfV1NW134jT/eCJ0NgyKZWOWM96TB2LBN+fCtwbbwmG9tg7D3zCXYVZXG8cw==", "ab171b0e-b644-4858-8cd1-7341c6afc76b" });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 196, DateTimeKind.Local).AddTicks(1717), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(2618) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4084), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4085) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4089), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4089) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4166), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4166) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4168), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4174), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4176), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4176) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4178), new DateTime(2024, 12, 18, 11, 39, 11, 197, DateTimeKind.Local).AddTicks(4178) });

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "licenciaconducir",
                keyColumn: "Id",
                keyValue: (byte)8,
                column: "Nivel",
                value: (byte)8);

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "licenciaconducir",
                keyColumn: "Id",
                keyValue: (byte)9,
                column: "Nivel",
                value: (byte)9);

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(3732), new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4509), new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4509) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4511), new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4511) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4513), new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4513) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4515), new DateTime(2024, 12, 18, 11, 39, 11, 198, DateTimeKind.Local).AddTicks(4515) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "licenciaconducir",
                keyColumn: "Id",
                keyValue: (byte)8,
                column: "Nivel",
                value: (byte)7);

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "licenciaconducir",
                keyColumn: "Id",
                keyValue: (byte)9,
                column: "Nivel",
                value: (byte)7);

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
        }
    }
}
