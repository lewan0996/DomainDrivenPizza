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
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsSpicy = table.Column<bool>(nullable: true),
                    IsVegetarian = table.Column<bool>(nullable: true),
                    IsVegan = table.Column<bool>(nullable: true),
                    CrustType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                schema: "Menu",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => new { x.PizzaId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Products_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "Menu",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Products_PizzaId",
                        column: x => x.PizzaId,
                        principalSchema: "Menu",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientId",
                schema: "Menu",
                table: "PizzaIngredient",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngredient",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Menu");

            migrationBuilder.DropSequence(
                name: "MenuHiLoSequence",
                schema: "Menu");
        }
    }
}
