using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    public partial class CambiosBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoActivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    confidencialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    integridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clas_conf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clas_int = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clas_disp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Amenaza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreAmenaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionAmenaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenaza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vulnerabilidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreVulnerabilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionVulnerabilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cvss = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vulnerabilidad", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activo");

            migrationBuilder.DropTable(
                name: "Amenaza");

            migrationBuilder.DropTable(
                name: "Vulnerabilidad");
        }
    }
}
