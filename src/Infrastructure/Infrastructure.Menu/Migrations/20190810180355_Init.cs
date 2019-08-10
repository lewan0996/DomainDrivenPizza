using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Menu.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateSequence(
                name: "MenuHiLoSequence",
                schema: "Menu",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsSpicy = table.Column<bool>(nullable: true),
                    IsVegetarian = table.Column<bool>(nullable: true),
                    IsVegan = table.Column<bool>(nullable: true),
                    PizzaId = table.Column<int>(nullable: true),
                    CrustType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_PizzaId",
                        column: x => x.PizzaId,
                        principalSchema: "Menu",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PizzaId",
                schema: "Menu",
                table: "Products",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Menu");

            migrationBuilder.DropSequence(
                name: "MenuHiLoSequence",
                schema: "Menu");
        }
    }
}
