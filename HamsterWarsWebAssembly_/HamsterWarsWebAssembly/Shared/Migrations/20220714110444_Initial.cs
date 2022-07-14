using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWarsWebAssembly.Shared.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FavFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loves = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters_Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamsterId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    WinStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hamsters_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hamsters_Games_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "FavFood", "Games", "ImgName", "Losses", "Loves", "Name", "Wins" },
                values: new object[,]
                {
                    { 1, 2, "Peanuts", 0, "/images/hamster-15.jpg", 0, "Wheel", "Emperor", 0 },
                    { 2, 2, "Seeds", 0, "/images/hamster-25.jpg", 0, "Water bottle", "Arcturus", 0 },
                    { 3, 1, "Bacon", 0, "/images/hamster-24.jpg", 0, "Corner", "Dissection", 0 },
                    { 4, 2, "Salad", 0, "/images/hamster-14.jpg", 0, "Sleeping", "Urfaust", 0 },
                    { 5, 1, "Carrot", 0, "/images/hamster-35.jpg", 0, "Walking", "Burzum", 0 },
                    { 6, 4, "Beans", 0, "/images/hamster-23.jpg", 0, "Dominating", "Morbid Angel", 0 },
                    { 7, 2, "Meat", 0, "/images/hamster-38.jpg", 0, "Biting", "Fleshgod Apocalypse", 0 },
                    { 8, 3, "Apple", 0, "/images/hamster-40.jpg", 0, "Jumping", "Carcass", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_Games_GameId",
                table: "Hamsters_Games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_Games_HamsterId",
                table: "Hamsters_Games",
                column: "HamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hamsters_Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Hamsters");
        }
    }
}
