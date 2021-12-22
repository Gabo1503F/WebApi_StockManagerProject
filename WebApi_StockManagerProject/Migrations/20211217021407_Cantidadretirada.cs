using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    public partial class Cantidadretirada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadRetirada",
                table: "PedidoHerramientas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadRetirada",
                table: "PedidoHerramientas");
        }
    }
}
