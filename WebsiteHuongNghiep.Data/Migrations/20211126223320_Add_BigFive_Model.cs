using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class Add_BigFive_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BigFiveResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigFiveResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BigFiveTrackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigFiveTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BigFiveTrackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BigFiveQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BigFiveResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigFiveQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BigFiveQuestions_BigFiveResults_BigFiveResultId",
                        column: x => x.BigFiveResultId,
                        principalTable: "BigFiveResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "ca713c9d-6e85-4425-967c-c85b66a26953");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "9857ced8-33c6-4be4-bd19-1fbaa3b811bf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "11d4a42c-8d1a-4e83-af6f-f2bbd99a89dc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f28f10d5-9d94-4a00-b233-e97b39da85e6", "AQAAAAEAACcQAAAAEJ15Fv8daZaajZaZZJiBkTGJzbE5lHo3WBCBrHybIw2Tn5O1GmEkvCbTSXFRXwFnmA==" });

            migrationBuilder.CreateIndex(
                name: "IX_BigFiveQuestions_BigFiveResultId",
                table: "BigFiveQuestions",
                column: "BigFiveResultId");

            migrationBuilder.CreateIndex(
                name: "IX_BigFiveTrackers_UserId",
                table: "BigFiveTrackers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BigFiveQuestions");

            migrationBuilder.DropTable(
                name: "BigFiveTrackers");

            migrationBuilder.DropTable(
                name: "BigFiveResults");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "634a8c3b-9fe8-44a1-824f-0ab91fd0250e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "e960cba1-666f-467c-8180-bc586a0a034c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "e3271b21-55bd-47b9-aa1e-02bccc70d22d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1805bfec-4816-4885-a30b-4c3090376382", "AQAAAAEAACcQAAAAEKq1O8N9EtzCFTzKOC8HJ7ttaZ/xaIIgxoHRZFGGe+0eCBiQGoHZyO4+cxWnuwlmqQ==" });
        }
    }
}
