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
                    { new Guid("2f46b2a9-9119-46a6-8907-38fcca07ab99"), "type", 0 },
                    { new Guid("1a185093-9699-427c-a507-9d3b97af1d07"), "type", 1 },
                    { new Guid("95382d2c-feea-41fa-80f1-7b79b6c41293"), "type", 2 },
                    { new Guid("450996c0-1a06-47e2-b97c-ce99e6774dce"), "type", 3 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "Computer", "Handle", "Password" },
                values: new object[] { new Guid("a05e7a2e-3e97-4b54-bec5-c2aa57512a8b"), true, "", "" });
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
