using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class RatingsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "JournalEntries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RatingEntry",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingTotal",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "RatingEntry",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "RatingTotal",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Items");
        }
    }
}
