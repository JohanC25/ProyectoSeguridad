using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    public partial class Cambios4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreActivo",
                table: "Control");

            migrationBuilder.AddColumn<int>(
                name: "ActivoId",
                table: "Control",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivoId",
                table: "Control");

            migrationBuilder.AddColumn<string>(
                name: "nombreActivo",
                table: "Control",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
