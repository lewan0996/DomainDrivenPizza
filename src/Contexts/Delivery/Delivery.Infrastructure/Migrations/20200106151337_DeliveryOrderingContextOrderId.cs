using Microsoft.EntityFrameworkCore.Migrations;

namespace Delivery.Infrastructure.Migrations
{
    public partial class DeliveryOrderingContextOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderingContextOrderId",
                schema: "Delivery",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderingContextOrderId",
                schema: "Delivery",
                table: "Orders");
        }
    }
}
