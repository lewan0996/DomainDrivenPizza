using Microsoft.EntityFrameworkCore.Migrations;

namespace Menu.Infrastructure.Migrations
{
    public partial class MenuRemovePizzaAvaliableQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                schema: "Menu",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                schema: "Menu",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
