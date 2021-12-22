using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    public partial class Herramienta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Herramientas",
                newName: "CantidadTotal");

            migrationBuilder.AddColumn<int>(
                name: "CantidadOcupada",
                table: "Herramientas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadOcupada",
                table: "Herramientas");

            migrationBuilder.RenameColumn(
                name: "CantidadTotal",
                table: "Herramientas",
                newName: "Cantidad");
        }
    }
}
