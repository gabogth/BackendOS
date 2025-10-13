using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class indexOrdenTrabajoMantenimientoExternoF1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orden_trabajo_detalle_orden_trabajo_detalle_activo_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle");

            migrationBuilder.AddForeignKey(
                name: "FK_orden_trabajo_detalle_activo_orden_trabajo_detalle_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle_activo",
                column: "Id",
                principalSchema: "mantto",
                principalTable: "orden_trabajo_detalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orden_trabajo_detalle_activo_orden_trabajo_detalle_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle_activo");

            migrationBuilder.AddForeignKey(
                name: "FK_orden_trabajo_detalle_orden_trabajo_detalle_activo_Id",
                schema: "mantto",
                table: "orden_trabajo_detalle",
                column: "Id",
                principalSchema: "mantto",
                principalTable: "orden_trabajo_detalle_activo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
