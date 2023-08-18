using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class Adding_Advertisment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hyperlink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath02 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath03 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath04 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoPath01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gif01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tyoe = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adverts");
        }
    }
}
