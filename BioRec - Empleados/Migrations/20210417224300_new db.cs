using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioRec___Empleados.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    idPais = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.idPais);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: false),
                    cantidadTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProducto);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    idDepartamento = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    departamento = table.Column<string>(nullable: false),
                    idPais = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.idDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_idPais",
                        column: x => x.idPais,
                        principalTable: "Pais",
                        principalColumn: "idPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CiudadDepPais",
                columns: table => new
                {
                    idCiudadDepPais = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ciudad = table.Column<string>(nullable: false),
                    idDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadDepPais", x => x.idCiudadDepPais);
                    table.ForeignKey(
                        name: "FK_CiudadDepPais_Departamento_idDepartamento",
                        column: x => x.idDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    idProveedor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreProveedor = table.Column<string>(nullable: false),
                    direccionBodega = table.Column<string>(nullable: false),
                    tipoVia = table.Column<string>(nullable: false),
                    numeroVia = table.Column<string>(nullable: false),
                    numeroViaSecundario = table.Column<string>(nullable: false),
                    numeroCasa = table.Column<string>(nullable: false),
                    tipoInmueble = table.Column<string>(nullable: true),
                    numeroInmueble = table.Column<string>(nullable: true),
                    idCiudadDepPais = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.idProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedor_CiudadDepPais_idCiudadDepPais",
                        column: x => x.idCiudadDepPais,
                        principalTable: "CiudadDepPais",
                        principalColumn: "idCiudadDepPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: false),
                    apellido = table.Column<string>(nullable: false),
                    fechanacimiento = table.Column<DateTime>(nullable: false),
                    edad = table.Column<int>(nullable: false),
                    correo = table.Column<string>(nullable: false),
                    contraseña = table.Column<string>(nullable: false),
                    rol = table.Column<int>(nullable: false),
                    tipoVia = table.Column<string>(nullable: false),
                    numeroVia = table.Column<string>(nullable: false),
                    numeroViaSecundario = table.Column<string>(nullable: false),
                    numeroCasa = table.Column<string>(nullable: false),
                    tipoInmueble = table.Column<string>(nullable: true),
                    numeroInmueble = table.Column<string>(nullable: true),
                    idCiudadDepPais = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_CiudadDepPais_idCiudadDepPais",
                        column: x => x.idCiudadDepPais,
                        principalTable: "CiudadDepPais",
                        principalColumn: "idCiudadDepPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor_Producto",
                columns: table => new
                {
                    idProveedor_Producto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(nullable: false),
                    cantidadTotal = table.Column<int>(nullable: false),
                    costoPorUnidad = table.Column<int>(nullable: false),
                    idProducto = table.Column<int>(nullable: false),
                    idProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor_Producto", x => x.idProveedor_Producto);
                    table.ForeignKey(
                        name: "FK_Proveedor_Producto_Producto_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedor_Producto_Proveedor_idProveedor",
                        column: x => x.idProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "idProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    idTelefono = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.idTelefono);
                    table.ForeignKey(
                        name: "FK_Telefono_Proveedor_idProveedor",
                        column: x => x.idProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "idProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    idVenta = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fechaYHoraVenta = table.Column<DateTime>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.idVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto_Venta",
                columns: table => new
                {
                    idProducto_Venta = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    precioTotalProducto = table.Column<int>(nullable: false),
                    cantidadProducto = table.Column<int>(nullable: false),
                    precioUnidad = table.Column<int>(nullable: false),
                    idVenta = table.Column<int>(nullable: false),
                    idProducto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_Venta", x => x.idProducto_Venta);
                    table.ForeignKey(
                        name: "FK_Producto_Venta_Producto_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Venta_Venta_idVenta",
                        column: x => x.idVenta,
                        principalTable: "Venta",
                        principalColumn: "idVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CiudadDepPais_idDepartamento",
                table: "CiudadDepPais",
                column: "idDepartamento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_idPais",
                table: "Departamento",
                column: "idPais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Venta_idProducto",
                table: "Producto_Venta",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Venta_idVenta",
                table: "Producto_Venta",
                column: "idVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_idCiudadDepPais",
                table: "Proveedor",
                column: "idCiudadDepPais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Producto_idProducto",
                table: "Proveedor_Producto",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Producto_idProveedor",
                table: "Proveedor_Producto",
                column: "idProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_idProveedor",
                table: "Telefono",
                column: "idProveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idCiudadDepPais",
                table: "Usuario",
                column: "idCiudadDepPais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_idUsuario",
                table: "Venta",
                column: "idUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto_Venta");

            migrationBuilder.DropTable(
                name: "Proveedor_Producto");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CiudadDepPais");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
