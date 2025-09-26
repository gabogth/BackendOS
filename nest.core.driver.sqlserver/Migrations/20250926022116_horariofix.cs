using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.sqlserver.Migrations
{
    /// <inheritdoc />
    public partial class horariofix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle_audit");

            migrationBuilder.DropColumn(
                name: "Item",
                schema: "rrhh",
                table: "horario_detalle");
        }
    }
}
