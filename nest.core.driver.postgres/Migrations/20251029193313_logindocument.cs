using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class logindocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal_audit",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_personal_UsuarioId",
                schema: "rrhh",
                table: "personal",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_personal_AspNetUsers_UsuarioId",
                schema: "rrhh",
                table: "personal",
                column: "UsuarioId",
                principalSchema: "security",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personal_AspNetUsers_UsuarioId",
                schema: "rrhh",
                table: "personal");

            migrationBuilder.DropIndex(
                name: "IX_personal_UsuarioId",
                schema: "rrhh",
                table: "personal");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal_audit");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "rrhh",
                table: "personal");
        }
    }
}
