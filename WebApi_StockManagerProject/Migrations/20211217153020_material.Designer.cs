// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_StockManagerProject;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211217153020_material")]
    partial class material
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Herramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadOcupada")
                        .HasColumnType("int");

                    b.Property<int>("CantidadTotal")
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Herramientas");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadOcupada")
                        .HasColumnType("int");

                    b.Property<int>("CantidadTotal")
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Trabajador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.PedidoHerramienta", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("HerramientaId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadRetirada")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "HerramientaId");

                    b.HasIndex("HerramientaId");

                    b.ToTable("PedidoHerramientas");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.PedidoMaterial", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadRetirada")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("PedidoMateriales");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("JefeProyecto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Pedido", b =>
                {
                    b.HasOne("WebApi_StockManagerProject.Entidades.Proyecto", "Proyecto")
                        .WithMany("Pedido")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.PedidoHerramienta", b =>
                {
                    b.HasOne("WebApi_StockManagerProject.Entidades.Herramienta", "Herramienta")
                        .WithMany("PedidoHerramientas")
                        .HasForeignKey("HerramientaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_StockManagerProject.Entidades.Pedido", "Pedido")
                        .WithMany("PedidoHerramientas")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Herramienta");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.PedidoMaterial", b =>
                {
                    b.HasOne("WebApi_StockManagerProject.Entidades.Material", "Material")
                        .WithMany("PedidoMateriales")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_StockManagerProject.Entidades.Pedido", "Pedido")
                        .WithMany("PedidoMateriales")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Herramienta", b =>
                {
                    b.Navigation("PedidoHerramientas");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Material", b =>
                {
                    b.Navigation("PedidoMateriales");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Pedido", b =>
                {
                    b.Navigation("PedidoHerramientas");

                    b.Navigation("PedidoMateriales");
                });

            modelBuilder.Entity("WebApi_StockManagerProject.Entidades.Proyecto", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
