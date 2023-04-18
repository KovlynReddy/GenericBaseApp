using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class CartItemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsPaid",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsPaid",
                table: "PurchasedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "PurchasedItems");
        }
    }
}
