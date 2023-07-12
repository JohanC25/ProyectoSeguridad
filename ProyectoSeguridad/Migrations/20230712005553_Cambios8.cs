using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    public partial class Cambios8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivoValor",
                table: "Calculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmenazaValor",
                table: "Calculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VulnerabilidadValor",
                table: "Calculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivoValor",
                table: "Calculos");

            migrationBuilder.DropColumn(
                name: "AmenazaValor",
                table: "Calculos");

            migrationBuilder.DropColumn(
                name: "VulnerabilidadValor",
                table: "Calculos");
        }
    }
}
