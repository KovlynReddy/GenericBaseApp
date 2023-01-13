using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorAPI.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArriveTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interactions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKUCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArriveTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeSent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeRecieved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeResponded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttatchmentString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Read = table.Column<int>(type: "int", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature = table.Column<int>(type: "int", nullable: false),
                    Interactions = table.Column<int>(type: "int", nullable: false),
                    AttatchmentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePurchased = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false),
                    DatePurchased = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReplied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ModelGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Caption", "CompletedDateTime", "Country", "CreatedDateTime", "CreatorId", "DeletedDateTime", "IsDeleted", "Lat", "MainStreet", "ModelGUID", "Name", "Number", "PostCode", "Street", "Suburb", "UserGuid", "lon" },
                values: new object[,]
                {
                    { 1, "Test01", "", "USA", "0001/01/01 00:00:00", "C1111", "", 0, "1000", "Street10", "A1111", "", "3", "1111", "Street1", "Sub1", "", "1111" },
                    { 2, "Test03", "", "USB", "0001/01/01 00:00:00", "C2222", "", 0, "2000", "Street20", "A2222", "", "6", "2222", "Sreet2", "Sub2", "", "2222" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompletedDateTime", "CreatedDateTime", "CreatorId", "CustomerAddress", "CustomerEmail", "CustomerName", "DeletedDateTime", "Email", "IsDeleted", "ModelGUID", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "0001/01/01 00:00:00", "0001/01/01 00:00:00", "C1111", "A1111", "Customer1@gmail.com", "Customer1", "", "Customer1@gmail.com", 0, "C1111", "1", "Customer1" },
                    { 2, "0001/01/01 00:00:00", "0001/01/01 00:00:00", "C2222", "A2222", "Customer2@gmail.com", "Customer2", "", "Customer2@gmail.com", 0, "C2222", "2", "Customer2" }
                });

            migrationBuilder.InsertData(
                table: "LogVisits",
                columns: new[] { "Id", "ArriveTime", "BarberGuid", "BookingTime", "CompletedDateTime", "CompletionTime", "CreatedDateTime", "CreatorId", "DeletedDateTime", "Description", "IsDeleted", "ModelGUID", "Rating", "Reason", "UserGuid" },
                values: new object[,]
                {
                    { 1, "0001/01/01 00:00:00", "B1111", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "C1111", "", "Booking", 0, "V1111", 2, "Hair Cut", "C1111" },
                    { 2, "0001/01/01 00:00:00", "B2222", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "0001/01/01 00:00:00", "C2222", "", "Walk In", 0, "V2222", 2, "Booking ", "C2222" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AddressGuid", "AverageRating", "CompletedDateTime", "CreatedDateTime", "CreatorId", "DeletedDateTime", "IsDeleted", "ModelGUID", "Status", "VendorEmail", "VendorName" },
                values: new object[,]
                {
                    { 1, "A1111", "10", "", "0001/01/01 00:00:00", "C1111", "", 0, "B1111", 0, "barber1@gmail.com", "Barber1" },
                    { 2, "A2222", "1", "", "0001/01/01 00:00:00", "C2222", "", 0, "B2222", 0, "barber2@gmail.com", "Barber2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "LogVisits");

            migrationBuilder.DropTable(
                name: "MeetUps");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PurchasedItems");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
