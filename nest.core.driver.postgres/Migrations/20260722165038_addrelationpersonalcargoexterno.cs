using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addrelationpersonalcargoexterno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_personal_cargo_externo_PersonalId",
                schema: "rrhh",
                table: "personal_cargo_externo",
                column: "PersonalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_personal_cargo_externo_PersonalId",
                schema: "rrhh",
                table: "personal_cargo_externo");
        }
    }
}
