using Microsoft.EntityFrameworkCore.Migrations;

namespace Delivery.Infrastructure.Migrations
{
    public partial class DeliverySupplierSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "Delivery",
                table: "OrderItems");

            migrationBuilder.InsertData(
                schema: "Delivery",
                table: "Suppliers",
                columns: new[] { "Id", "FirstName", "LastName", "Status" },
                values: new object[] { 1, "Jan", "Kowalski", "Free" });

            migrationBuilder.InsertData(
                schema: "Delivery",
                table: "Suppliers",
                columns: new[] { "Id", "FirstName", "LastName", "Status" },
                values: new object[] { 2, "Adam", "Nowak", "Free" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Delivery",
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Delivery",
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "Delivery",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
