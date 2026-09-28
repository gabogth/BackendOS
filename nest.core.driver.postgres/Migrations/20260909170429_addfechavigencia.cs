using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class addfechavigencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVigencia",
                schema: "mantto",
                table: "orden_trabajo_horario_audit",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVigencia",
                schema: "mantto",
                table: "orden_trabajo_horario",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVigencia",
                schema: "mantto",
                table: "orden_trabajo_horario_audit");

            migrationBuilder.DropColumn(
                name: "FechaVigencia",
                schema: "mantto",
                table: "orden_trabajo_horario");
        }
    }
}
