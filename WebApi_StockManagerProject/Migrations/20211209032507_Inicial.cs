using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herramientas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JefeProyecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trabajador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoHerramientas",
                columns: table => new
                {
                    HerramientaId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoHerramientas", x => new { x.PedidoId, x.HerramientaId });
                    table.ForeignKey(
                        name: "FK_PedidoHerramientas_Herramientas_HerramientaId",
                        column: x => x.HerramientaId,
                        principalTable: "Herramientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoHerramientas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoMateriales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoMateriales", x => new { x.PedidoId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_PedidoMateriales_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoMateriales_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoHerramientas_HerramientaId",
                table: "PedidoHerramientas",
                column: "HerramientaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMateriales_MaterialId",
                table: "PedidoMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProyectoId",
                table: "Pedidos",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoHerramientas");

            migrationBuilder.DropTable(
                name: "PedidoMateriales");

            migrationBuilder.DropTable(
                name: "Herramientas");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
