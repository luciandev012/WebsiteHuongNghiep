using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class AddColumn_MbtiTablePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "MbtiTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "MbtiTables");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "d8376afb-09c9-451f-8aa8-480ab9f87dd4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "49cd487c-7409-40d7-b1c2-5ca0a9e349ad");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "4a477d78-8102-4eea-9bc4-07b13e83199a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b49ecf1-720c-4c08-8aa6-66b0f70ea3e4", "AQAAAAEAACcQAAAAEEXV13dT8Vsrp7tpfxcprFSlslyho6oKzKFzM+rLGCjP1oFkPoWq6cdU3/dAZVbFmA==" });
        }
    }
}
