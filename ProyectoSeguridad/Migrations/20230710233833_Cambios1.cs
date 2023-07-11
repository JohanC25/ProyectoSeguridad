using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    public partial class Cambios1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Controlid",
                table: "Activo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Control",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    efectividad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activo_Control_Controlid",
                table: "Activo");

            migrationBuilder.DropTable(
                name: "Control");

            migrationBuilder.DropIndex(
                name: "IX_Activo_Controlid",
                table: "Activo");

            migrationBuilder.DropColumn(
                name: "Controlid",
                table: "Activo");
        }
    }
}
