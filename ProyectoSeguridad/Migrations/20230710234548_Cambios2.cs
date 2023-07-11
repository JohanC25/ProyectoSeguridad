using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    public partial class Cambios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activo_Control_Controlid",
                table: "Activo");

            migrationBuilder.DropIndex(
                name: "IX_Activo_Controlid",
                table: "Activo");

            migrationBuilder.DropColumn(
                name: "Controlid",
                table: "Activo");

            migrationBuilder.AddColumn<string>(
                name: "nombreActivo",
                table: "Control",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreActivo",
                table: "Control");

            migrationBuilder.AddColumn<int>(
                name: "Controlid",
                table: "Activo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activo_Controlid",
                table: "Activo",
                column: "Controlid");

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_Control_Controlid",
                table: "Activo",
                column: "Controlid",
                principalTable: "Control",
                principalColumn: "id");
        }
    }
}
