using Microsoft.EntityFrameworkCore.Migrations;

namespace Menu.Infrastructure.Migrations
{
    public partial class MenuRemoveCrustType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrustType",
                schema: "Menu",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CrustType",
                schema: "Menu",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
