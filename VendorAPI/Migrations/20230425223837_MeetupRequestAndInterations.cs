using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class MeetupRequestAndInterations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserGuid",
                table: "PostInteractions",
                newName: "SentDateTime");

            migrationBuilder.RenameColumn(
                name: "PostOwnerGuid",
                table: "PostInteractions",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "InteractionId",
                table: "PostInteractions",
                newName: "SenderGuid");

            migrationBuilder.RenameColumn(
                name: "InteractionGuid",
                table: "PostInteractions",
                newName: "ReaderGuid");

            migrationBuilder.RenameColumn(
                name: "InteractionDate",
                table: "PostInteractions",
                newName: "ReadDateTime");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "PostInteractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PostInteractions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PostInteractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeetUpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetupGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SentDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetUpRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetUpRequests");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "PostInteractions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PostInteractions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PostInteractions");

            migrationBuilder.RenameColumn(
                name: "SentDateTime",
                table: "PostInteractions",
                newName: "UserGuid");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "PostInteractions",
                newName: "PostOwnerGuid");

            migrationBuilder.RenameColumn(
                name: "SenderGuid",
                table: "PostInteractions",
                newName: "InteractionId");

            migrationBuilder.RenameColumn(
                name: "ReaderGuid",
                table: "PostInteractions",
                newName: "InteractionGuid");

            migrationBuilder.RenameColumn(
                name: "ReadDateTime",
                table: "PostInteractions",
                newName: "InteractionDate");
        }
    }
}
