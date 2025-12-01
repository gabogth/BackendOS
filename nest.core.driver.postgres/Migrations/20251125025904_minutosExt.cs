using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class minutosExt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera_audit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumTtra",
                schema: "logistica",
                table: "inventario_cabecera",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera_audit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera_audit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosDescanso",
                schema: "rrhh",
                table: "horario_cabecera",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinutosTraslado",
                schema: "rrhh",
                table: "horario_cabecera",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
