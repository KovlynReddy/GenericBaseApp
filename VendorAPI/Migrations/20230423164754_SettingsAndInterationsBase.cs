using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class SettingsAndInterationsBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedTheme",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PostInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteractionGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOwnerGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInteractions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SelectedTheme",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SelectedTheme",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostInteractions");

            migrationBuilder.DropColumn(
                name: "SelectedTheme",
                table: "Customers");
        }
    }
}
