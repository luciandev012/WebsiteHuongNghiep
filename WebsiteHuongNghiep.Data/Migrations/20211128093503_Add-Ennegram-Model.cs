using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class AddEnnegramModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnnegramResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnnegramResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnnegramTrackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnnegramTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnnegramTrackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "6be52187-0400-4b38-ad51-e241133cd027");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "aa4a4f5e-376a-469a-aea0-5c203e726222");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "91dc03e5-a9aa-4baa-84d3-8cdce16a8a65");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "676f1686-b780-4ba8-8040-bdd42d721490", "AQAAAAEAACcQAAAAEIoHTef86yGyBVMsA6fbtmDJvnHyGn2ZMp92kpYa+ffvRk/S5C6iXyQtQxzPGelXqA==" });

            migrationBuilder.CreateIndex(
                name: "IX_EnnegramTrackers_UserId",
                table: "EnnegramTrackers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnnegramResults");

            migrationBuilder.DropTable(
                name: "EnnegramTrackers");

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
        }
    }
}
