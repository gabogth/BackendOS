using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addMardcacionLatLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia_audit",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia_audit",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                schema: "rrhh",
                table: "registro_asistencia",
                type: "numeric(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                schema: "rrhh",
                table: "registro_asistencia",
                type: "numeric(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
