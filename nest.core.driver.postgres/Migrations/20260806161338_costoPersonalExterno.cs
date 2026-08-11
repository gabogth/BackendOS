using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class costoPersonalExterno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostoHombre",
                schema: "rrhh",
                table: "personal_cargo_externo_audit",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoHombre",
                schema: "rrhh",
                table: "personal_cargo_externo",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoHombre",
                schema: "rrhh",
                table: "personal_cargo_externo_audit");

            migrationBuilder.DropColumn(
                name: "CostoHombre",
                schema: "rrhh",
                table: "personal_cargo_externo");
        }
    }
}
