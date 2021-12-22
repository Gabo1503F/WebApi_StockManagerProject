using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    public partial class material : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Materials",
                newName: "CantidadTotal");

            migrationBuilder.AddColumn<int>(
                name: "CantidadRetirada",
                table: "PedidoMateriales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadOcupada",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadRetirada",
                table: "PedidoMateriales");

            migrationBuilder.DropColumn(
                name: "CantidadOcupada",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "CantidadTotal",
                table: "Materials",
                newName: "Cantidad");
        }
    }
}
