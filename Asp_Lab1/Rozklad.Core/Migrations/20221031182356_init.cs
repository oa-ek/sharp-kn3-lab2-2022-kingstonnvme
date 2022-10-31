using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rozklad.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Cards",
                columns: table => new
                {
                    cardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomerCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC_kod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.cardId);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    carrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.carrierId);
                });

            migrationBuilder.CreateTable(
                name: "MapsRoutes",
                columns: table => new
                {
                    mapsRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoordinateOfDeparture = table.Column<float>(type: "real", nullable: false),
                    CoordinateOfArrival = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapsRoutes", x => x.mapsRouteId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    statusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.statusId);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "BuyTickets",
                columns: table => new
                {
                    buyTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTicket = table.Column<int>(type: "int", nullable: false),
                    NomerTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllPrice = table.Column<int>(type: "int", nullable: false),
                    cardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyTickets", x => x.buyTicketId);
                    table.ForeignKey(
                        name: "FK_BuyTickets_Cards_cardId",
                        column: x => x.cardId,
                        principalTable: "Cards",
                        principalColumn: "cardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusRoutes",
                columns: table => new
                {
                    BusrouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceOfDeparture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntermediateStops = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfArrival = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mapsRouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoutes", x => x.BusrouteId);
                    table.ForeignKey(
                        name: "FK_BusRoutes_MapsRoutes_mapsRouteId",
                        column: x => x.mapsRouteId,
                        principalTable: "MapsRoutes",
                        principalColumn: "mapsRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusShedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusrouteId = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    carrierId = table.Column<int>(type: "int", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    buyTicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusShedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusShedules_BusRoutes_BusrouteId",
                        column: x => x.BusrouteId,
                        principalTable: "BusRoutes",
                        principalColumn: "BusrouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusShedules_BuyTickets_buyTicketId",
                        column: x => x.buyTicketId,
                        principalTable: "BuyTickets",
                        principalColumn: "buyTicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusShedules_Carriers_carrierId",
                        column: x => x.carrierId,
                        principalTable: "Carriers",
                        principalColumn: "carrierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusShedules_Statuses_statusId",
                        column: x => x.statusId,
                        principalTable: "Statuses",
                        principalColumn: "statusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95c8af7b-a99f-4d4a-b22b-0489fbe786ca", "25cc7aeb-27a7-4c82-836a-f7740c9b2684", "Admin", "ADMIN" },
                    { "c376a58b-f60b-4f00-ba93-86d5275b9f40", "ea87057b-77c6-4e23-ab81-d7a413713eb0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6b2fdfc3-b068-4e85-8393-ea6a97324207", 0, "b2eaf644-ace3-4d5a-89c4-5d7933c3e8b1", "admin@rozklad.com", true, null, null, false, null, "ADMIN@ROZKLAD.COM", "ADMIN@ROZKLAD.COM", "AQAAAAEAACcQAAAAEOAEN75KbOmbTD6cmlgOyMYFuKTiUlfqVoneqFRPsYgU7Yww/4AouwVkI6bVoakyOQ==", null, false, "ce549884-52e6-4d5e-a096-80b82b8b1fe4", false, "admin@rozklad.com" },
                    { "c3688914-cf54-4caf-9ef2-d3b0a2c7f0d8", 0, "676dcbb6-c6f1-455a-8f22-7df9f3537a2b", "user@rozklad.com", true, null, null, false, null, "USER@ROZKLAD.COM", "USER@ROZKLAD.COM", "AQAAAAEAACcQAAAAECJWa05/xw1jf7ErdIyxqHfd4limZTxd69U8Q1H/i2NtiDFJiAqkkrf7AiSxI4ZTJg==", null, false, "980dd4b5-a05b-499a-9c1d-18425056f594", false, "user@rozklad.com" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "cardId", "CVC_kod", "DateEnd", "NomerCard" },
                values: new object[] { 1, "234", "01/26", "3t46363477" });

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "carrierId", "Name", "Transport" },
                values: new object[] { 1, "Ilias", "autobus" });

            migrationBuilder.InsertData(
                table: "MapsRoutes",
                columns: new[] { "mapsRouteId", "CoordinateOfArrival", "CoordinateOfDeparture" },
                values: new object[] { 1, 434f, 123f });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "statusId", "StatusValue" },
                values: new object[] { 1, "В дорозі" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95c8af7b-a99f-4d4a-b22b-0489fbe786ca", "6b2fdfc3-b068-4e85-8393-ea6a97324207" },
                    { "c376a58b-f60b-4f00-ba93-86d5275b9f40", "6b2fdfc3-b068-4e85-8393-ea6a97324207" },
                    { "c376a58b-f60b-4f00-ba93-86d5275b9f40", "c3688914-cf54-4caf-9ef2-d3b0a2c7f0d8" }
                });

            migrationBuilder.InsertData(
                table: "BusRoutes",
                columns: new[] { "BusrouteId", "IntermediateStops", "PlaceOfArrival", "PlaceOfDeparture", "mapsRouteId" },
                values: new object[] { 1, "gremzc", "Рівне", "Острог", 1 });

            migrationBuilder.InsertData(
                table: "BuyTickets",
                columns: new[] { "buyTicketId", "AllPrice", "BuyerName", "NomerTel", "cardId", "numTicket" },
                values: new object[] { 1, 125, "ilas", "78685895", 1, 3 });

            migrationBuilder.InsertData(
                table: "BusShedules",
                columns: new[] { "Id", "ArrivalTime", "BusrouteId", "Cost", "DepartureTime", "Seats", "buyTicketId", "carrierId", "statusId" },
                values: new object[] { 1, new DateTime(2022, 7, 20, 20, 30, 25, 0, DateTimeKind.Unspecified), 1, 75f, new DateTime(2022, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), 30, 1, 1, 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_BusRoutes_mapsRouteId",
                table: "BusRoutes",
                column: "mapsRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BusShedules_BusrouteId",
                table: "BusShedules",
                column: "BusrouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BusShedules_buyTicketId",
                table: "BusShedules",
                column: "buyTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_BusShedules_carrierId",
                table: "BusShedules",
                column: "carrierId");

            migrationBuilder.CreateIndex(
                name: "IX_BusShedules_statusId",
                table: "BusShedules",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyTickets_cardId",
                table: "BuyTickets",
                column: "cardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BusShedules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusRoutes");

            migrationBuilder.DropTable(
                name: "BuyTickets");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "MapsRoutes");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
