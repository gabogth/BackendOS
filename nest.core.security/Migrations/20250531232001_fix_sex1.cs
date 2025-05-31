using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.security.Migrations
{
    /// <inheritdoc />
    public partial class fix_sex1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "sexo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3653c8b-5075-44cc-8cc8-74c404fd7796", "AQAAAAIAAYagAAAAEAW+82kYFfshAu2JG4l9rOpAyDli7jg0PNKDMezOeXHxfwRpzmXscDUWYjS+1qGYWw==", "bd9c909e-7f41-46bd-8254-1486ded55be7" });

            migrationBuilder.UpdateData(
                schema: "security",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ae72d7f-6d8e-4d3b-a918-edb621a638e7", "AQAAAAIAAYagAAAAEK/rGBm013LQMjJ7Z1wsCn5AVlSguE47DeVImPEgkqaQPQN55u10v4rHXUgh4BBK/Q==", "428b4843-fc10-43c6-845b-dabd7c76886f" });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 712, DateTimeKind.Local).AddTicks(9166), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(2011) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3576), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3577) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3582), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3582) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3586), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3586) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3588), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3588) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3594), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3595) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3597), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3597) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "formulario",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3599), new DateTime(2025, 5, 31, 18, 20, 0, 714, DateTimeKind.Local).AddTicks(3599) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(3307), new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(3311) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4026), new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4026) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4029), new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4029) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4030), new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4031) });

            migrationBuilder.UpdateData(
                schema: "aplicacion",
                table: "modulo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4032), new DateTime(2025, 5, 31, 18, 20, 0, 715, DateTimeKind.Local).AddTicks(4032) });

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "sexo",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "NombreCorto",
                value: "H");

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "sexo",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "NombreCorto",
                value: "M");

            migrationBuilder.UpdateData(
                schema: "rrhh",
                table: "sexo",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "NombreCorto",
                value: "O");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCorto",
                schema: "rrhh",
                table: "sexo");

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
        }
    }
}
