﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TiendaDeVideojuegosWebApi.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20250204192810_totalCHange")]
    partial class totalCHange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Desarrollador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Desarrolladores");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Juego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("DesarrolladorId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarritoId");

                    b.HasIndex("DesarrolladorId");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Carrito", b =>
                {
                    b.HasOne("TiendaDeVideojuegosWebApi.Data.Usuario", "Usuario")
                        .WithOne("Carrito")
                        .HasForeignKey("TiendaDeVideojuegosWebApi.Data.Carrito", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Juego", b =>
                {
                    b.HasOne("TiendaDeVideojuegosWebApi.Data.Carrito", null)
                        .WithMany("Juegos")
                        .HasForeignKey("CarritoId");

                    b.HasOne("TiendaDeVideojuegosWebApi.Data.Desarrollador", "Desarrollador")
                        .WithMany("Juegos")
                        .HasForeignKey("DesarrolladorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desarrollador");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Carrito", b =>
                {
                    b.Navigation("Juegos");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Desarrollador", b =>
                {
                    b.Navigation("Juegos");
                });

            modelBuilder.Entity("TiendaDeVideojuegosWebApi.Data.Usuario", b =>
                {
                    b.Navigation("Carrito")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
