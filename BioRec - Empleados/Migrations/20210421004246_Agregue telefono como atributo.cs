using Microsoft.EntityFrameworkCore.Migrations;

namespace BioRec___Empleados.Migrations
{
    public partial class Agreguetelefonocomoatributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "Proveedor",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "telefono",
                table: "Proveedor");
        }
    }
}
