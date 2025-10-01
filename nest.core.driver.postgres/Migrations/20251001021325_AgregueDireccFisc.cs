using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class AgregueDireccFisc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona_audit",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona_audit");

            migrationBuilder.DropColumn(
                name: "DireccionFiscal",
                schema: "dbo",
                table: "persona");
        }
    }
}
