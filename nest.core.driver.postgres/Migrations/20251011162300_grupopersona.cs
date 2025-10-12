using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest.core.driver.postgres.Migrations
{
    /// <inheritdoc />
    public partial class grupopersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId",
                schema: "rrhh",
                table: "grupo_trabajo_persona");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "character varying(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId_PersonaId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                columns: new[] { "GrupoTrabajoId", "PersonaId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId_PersonaId",
                schema: "rrhh",
                table: "grupo_trabajo_persona");

            migrationBuilder.AlterColumn<int>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo_audit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NombreCorto",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "integer",
                maxLength: 9,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                schema: "rrhh",
                table: "grupo_trabajo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_grupo_trabajo_persona_GrupoTrabajoId",
                schema: "rrhh",
                table: "grupo_trabajo_persona",
                column: "GrupoTrabajoId");
        }
    }
}
