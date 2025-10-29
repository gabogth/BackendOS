using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class fixadjunto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registro_asistencia_adjunto_adjunto_Id",
                schema: "rrhh",
                table: "registro_asistencia_adjunto");

            migrationBuilder.CreateIndex(
                name: "IX_registro_asistencia_adjunto_AdjuntoId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
                column: "AdjuntoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_asistencia_adjunto_adjunto_AdjuntoId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
                column: "AdjuntoId",
                principalSchema: "dbo",
                principalTable: "adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registro_asistencia_adjunto_adjunto_AdjuntoId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto");

            migrationBuilder.DropIndex(
                name: "IX_registro_asistencia_adjunto_AdjuntoId",
                schema: "rrhh",
                table: "registro_asistencia_adjunto");

            migrationBuilder.AddForeignKey(
                name: "FK_registro_asistencia_adjunto_adjunto_Id",
                schema: "rrhh",
                table: "registro_asistencia_adjunto",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "adjunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
