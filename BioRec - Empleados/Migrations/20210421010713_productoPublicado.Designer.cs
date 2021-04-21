﻿// <auto-generated />
using System;
using BioRec___Empleados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BioRec___Empleados.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210421010713_productoPublicado")]
    partial class productoPublicado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BioRec___Empleados.Models.CiudadDepPais", b =>
                {
                    b.Property<int>("idCiudadDepPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("idDepartamento")
                        .HasColumnType("int");

                    b.HasKey("idCiudadDepPais");

                    b.HasIndex("idDepartamento")
                        .IsUnique();

                    b.ToTable("CiudadDepPais");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Departamento", b =>
                {
                    b.Property<int>("idDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("departamento")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("idPais")
                        .HasColumnType("int");

                    b.HasKey("idDepartamento");

                    b.HasIndex("idPais")
                        .IsUnique();

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Pais", b =>
                {
                    b.Property<int>("idPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("idPais");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cantidadTotal")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("idProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.ProductoPublicado", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("precio")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("ProductoPublicado");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Producto_Venta", b =>
                {
                    b.Property<int>("idProducto_Venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cantidadProducto")
                        .HasColumnType("int");

                    b.Property<int>("idProducto")
                        .HasColumnType("int");

                    b.Property<int>("idVenta")
                        .HasColumnType("int");

                    b.Property<int>("precioTotalProducto")
                        .HasColumnType("int");

                    b.Property<int>("precioUnidad")
                        .HasColumnType("int");

                    b.HasKey("idProducto_Venta");

                    b.HasIndex("idProducto");

                    b.HasIndex("idVenta");

                    b.ToTable("Producto_Venta");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Proveedor", b =>
                {
                    b.Property<int>("idProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("idCiudadDepPais")
                        .HasColumnType("int");

                    b.Property<string>("nombreProveedor")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroCasa")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroVia")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroViaSecundario")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoVia")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("idProveedor");

                    b.HasIndex("idCiudadDepPais")
                        .IsUnique();

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Proveedor_Producto", b =>
                {
                    b.Property<int>("idProveedor_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cantidadTotal")
                        .HasColumnType("int");

                    b.Property<int>("costoPorUnidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idProducto")
                        .HasColumnType("int");

                    b.Property<int>("idProveedor")
                        .HasColumnType("int");

                    b.HasKey("idProveedor_Producto");

                    b.HasIndex("idProducto");

                    b.HasIndex("idProveedor");

                    b.ToTable("Proveedor_Producto");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.RegistroProveedorViewModel", b =>
                {
                    b.Property<int>("idProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ciudad")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("departamento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nombreProveedor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroCasa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroVia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroViaSecundario")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("pais")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoVia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("idProveedor");

                    b.ToTable("RegistroProveedorViewModel");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Telefono", b =>
                {
                    b.Property<int>("idTelefono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("idProveedor")
                        .HasColumnType("int");

                    b.HasKey("idTelefono");

                    b.HasIndex("idProveedor")
                        .IsUnique();

                    b.ToTable("Telefono");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("contraseña")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechanacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idCiudadDepPais")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroCasa")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroVia")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("numeroViaSecundario")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("rol")
                        .HasColumnType("int");

                    b.Property<string>("tipoInmueble")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoVia")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("idUsuario");

                    b.HasIndex("idCiudadDepPais")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Venta", b =>
                {
                    b.Property<int>("idVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaYHoraVenta")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("idVenta");

                    b.HasIndex("idUsuario");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("BioRec___Empleados.Models.CiudadDepPais", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Departamento", "Departamento")
                        .WithOne("CiudadDepPais")
                        .HasForeignKey("BioRec___Empleados.Models.CiudadDepPais", "idDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Departamento", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Pais", "Pais")
                        .WithOne("Departamento")
                        .HasForeignKey("BioRec___Empleados.Models.Departamento", "idPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.ProductoPublicado", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Producto", "Producto")
                        .WithOne("ProductoPublicado")
                        .HasForeignKey("BioRec___Empleados.Models.ProductoPublicado", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Producto_Venta", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Producto", "Producto")
                        .WithMany("Producto_Ventas")
                        .HasForeignKey("idProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioRec___Empleados.Models.Venta", "Venta")
                        .WithMany("Producto_Ventas")
                        .HasForeignKey("idVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Proveedor", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.CiudadDepPais", "CiudadDepPais")
                        .WithOne("Proveedor")
                        .HasForeignKey("BioRec___Empleados.Models.Proveedor", "idCiudadDepPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Proveedor_Producto", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Producto", "Producto")
                        .WithMany("Proveedor_Producto")
                        .HasForeignKey("idProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioRec___Empleados.Models.Proveedor", "Proveedor")
                        .WithMany("Proveedor_Producto")
                        .HasForeignKey("idProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Telefono", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Proveedor", "Proveedor")
                        .WithOne("Telefono")
                        .HasForeignKey("BioRec___Empleados.Models.Telefono", "idProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Usuario", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.CiudadDepPais", "CiudadDepPais")
                        .WithOne("Usuario")
                        .HasForeignKey("BioRec___Empleados.Models.Usuario", "idCiudadDepPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioRec___Empleados.Models.Venta", b =>
                {
                    b.HasOne("BioRec___Empleados.Models.Usuario", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
