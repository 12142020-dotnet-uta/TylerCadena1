using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Janken.Runtime.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    ChoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.ChoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Computer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.InsertData(
                table: "Choice",
                columns: new[] { "ChoiceId", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("5e739768-8422-4e4b-9eae-f917d417f15c"), "type", 0 },
                    { new Guid("eedce8ef-9da8-4148-be16-3c905f9d334c"), "type", 1 },
                    { new Guid("14db97b0-e33d-4704-b474-6c29303a8c9a"), "type", 2 },
                    { new Guid("96c29708-7bed-4338-9266-22821a38993b"), "type", 3 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "Computer", "Handle", "Password" },
                values: new object[] { new Guid("cd62a0b8-1b65-43a2-8cd8-d00088d39d6c"), true, "Computer", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
