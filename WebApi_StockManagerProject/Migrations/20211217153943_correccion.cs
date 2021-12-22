using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_StockManagerProject.Migrations
{
    public partial class correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadOcupada",
                table: "Materials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadOcupada",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
