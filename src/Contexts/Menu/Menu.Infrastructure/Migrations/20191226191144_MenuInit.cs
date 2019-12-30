using Microsoft.EntityFrameworkCore.Migrations;
// ReSharper disable All

namespace Menu.Infrastructure.Migrations
{
    public partial class MenuInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    IsSpicy = table.Column<bool>(nullable: false),
                    IsVegetarian = table.Column<bool>(nullable: false),
                    IsVegan = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    CrustType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
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
                        name: "FK_PizzaIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "Menu",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalSchema: "Menu",
                        principalTable: "Pizzas",
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
                name: "Ingredients",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Pizzas",
                schema: "Menu");
        }
    }
}
