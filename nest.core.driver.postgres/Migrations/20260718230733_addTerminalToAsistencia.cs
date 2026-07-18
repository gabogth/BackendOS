using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addTerminalToAsistencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia_audit",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia",
                column: "TerminalBiometricoId");

            migrationBuilder.AddForeignKey(
                name: "FK_registro_asistencia_terminal_biometrico_TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia",
                column: "TerminalBiometricoId",
                principalSchema: "rrhh",
                principalTable: "terminal_biometrico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registro_asistencia_terminal_biometrico_TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia");

            migrationBuilder.DropIndex(
                name: "IX_registro_asistencia_TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia");

            migrationBuilder.DropColumn(
                name: "TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia_audit");

            migrationBuilder.DropColumn(
                name: "TerminalBiometricoId",
                schema: "rrhh",
                table: "registro_asistencia");
        }
    }
}
