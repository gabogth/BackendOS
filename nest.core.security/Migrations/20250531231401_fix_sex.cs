using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.security.Migrations
{
    /// <inheritdoc />
    public partial class fix_sex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_Sexo_SexoId",
                schema: "dbo",
                table: "persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sexo",
                table: "Sexo");

            migrationBuilder.RenameTable(
                name: "Sexo",
                newName: "sexo",
                newSchema: "rrhh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sexo",
                schema: "rrhh",
                table: "sexo",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbd77eeb-30c3-40e5-9f40-ec3cb7becaad", "AQAAAAIAAYagAAAAEHw5Dp11Zr7YG2hIZqFa7/0AMKZOLHVsLXW2FlwmipCbltu3WENSmiVk721BrLZHJQ==", "b699ed2c-6125-4b7b-86e8-7804fb6f45cd" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87401043-e8f9-475d-a359-2f07c2713bc8", "AQAAAAIAAYagAAAAEIPml1P1G8miCN0bbvAOmrcypN69NERkwCRR8G6/xU6NXjrrvYOZD4u6gteSeej7ew==", "f09aef6a-bd10-4e59-98c8-c0eba039ad60" });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 400, DateTimeKind.Local).AddTicks(7147), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1673), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1674) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1678), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1681), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1692), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1693) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1701), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1701) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1703), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1703) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1705), new DateTime(2025, 5, 31, 18, 14, 0, 402, DateTimeKind.Local).AddTicks(1705) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(269), new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1011), new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1011) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1014), new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1016), new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1016) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1017), new DateTime(2025, 5, 31, 18, 14, 0, 403, DateTimeKind.Local).AddTicks(1018) });

            migrationBuilder.AddForeignKey(
                name: "FK_persona_sexo_SexoId",
                schema: "dbo",
                table: "persona",
                column: "SexoId",
                principalSchema: "rrhh",
                principalTable: "sexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_sexo_SexoId",
                schema: "dbo",
                table: "persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sexo",
                schema: "rrhh",
                table: "sexo");

            migrationBuilder.RenameTable(
                name: "sexo",
                schema: "rrhh",
                newName: "Sexo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sexo",
                table: "Sexo",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d0b6e80-0b0e-4200-8720-c69d334157d1", "AQAAAAIAAYagAAAAEMUaIprzIZJz5cPabBdujnnxlzsYnWg8TkRO24SXWCMlItDyd3dI9Q12/31U3U9yLg==", "91d7a4a8-8c66-4ba1-9c61-ef21ae88cd55" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88c05a3b-1589-4399-bbe6-441f8ddb88c7", "AQAAAAIAAYagAAAAEJfe9vY6vrpbj/b4GWmSeFYEmZn2mcJRd75vhxDvp0bGUsheGnt1XHjZ3O0kKEah9A==", "16e3f3b6-1a34-4c9b-b3de-10cba0f3004c" });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 47, DateTimeKind.Local).AddTicks(5167), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8673), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8675) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8680), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8689), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8691), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8692) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8703), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8704) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8706), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8706) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8708), new DateTime(2025, 5, 31, 13, 59, 13, 49, DateTimeKind.Local).AddTicks(8708) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(638), new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(647) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1375), new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1375) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1378), new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1378) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1380), new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1380) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1381), new DateTime(2025, 5, 31, 13, 59, 13, 51, DateTimeKind.Local).AddTicks(1382) });

            migrationBuilder.AddForeignKey(
                name: "FK_persona_Sexo_SexoId",
                schema: "dbo",
                table: "persona",
                column: "SexoId",
                principalTable: "Sexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
