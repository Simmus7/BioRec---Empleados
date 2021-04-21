using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioRec___Empleados.Migrations
{
    public partial class productoPublicado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoPublicado",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPublicado", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductoPublicado_Producto_id",
                        column: x => x.id,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroProveedorViewModel",
                columns: table => new
                {
                    idProveedor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreProveedor = table.Column<string>(nullable: true),
                    tipoVia = table.Column<string>(nullable: true),
                    numeroVia = table.Column<string>(nullable: true),
                    numeroViaSecundario = table.Column<string>(nullable: true),
                    numeroCasa = table.Column<string>(nullable: true),
                    tipoInmueble = table.Column<string>(nullable: true),
                    numeroInmueble = table.Column<string>(nullable: true),
                    ciudad = table.Column<string>(nullable: true),
                    departamento = table.Column<string>(nullable: true),
                    pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroProveedorViewModel", x => x.idProveedor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoPublicado");

            migrationBuilder.DropTable(
                name: "RegistroProveedorViewModel");
        }
    }
}
