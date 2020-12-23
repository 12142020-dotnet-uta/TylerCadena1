using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Janken.Domain.Migrations
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
                    { new Guid("cc14662b-70d1-47cc-a007-f9935f269535"), "type", 0 },
                    { new Guid("a015cbca-5be3-4be9-9840-7b2ea8dbb1d8"), "type", 1 },
                    { new Guid("d4a3a6c5-b704-4dc1-b3f2-9cb5f5909bc4"), "type", 2 },
                    { new Guid("048570ac-0f55-4601-8f12-6eb56018ed65"), "type", 3 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "Computer", "Handle", "Password" },
                values: new object[] { new Guid("60bc35fe-6df3-40c6-bb84-238ba70df681"), true, "Computer", "" });
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
