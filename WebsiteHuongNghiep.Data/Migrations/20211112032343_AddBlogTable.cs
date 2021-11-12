using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class AddBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "238de137-a7cd-43c6-8b7a-e6762f442c5d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "e23ba8a6-5b22-4dac-9c0f-9315adefa500");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "6d7b8bd2-bcca-40b5-ac81-982b7174f417");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c6eecf1-eed0-4795-9430-bda635d87cab", "AQAAAAEAACcQAAAAEBJu1krAo303oKq6mjob/Kakta7vQXr9L8ZL0L1vSByS73PPwzp3OFM3yul4XBuZog==" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "0618a573-25bd-4d71-899e-23052490eaf5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "48ef674c-f5c3-432e-85e1-e077361e5cff");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "718b31d2-4ade-441a-acdf-c86c8cfdc7cc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6487aa4-c945-4885-9b49-6fa1ed292887", "AQAAAAEAACcQAAAAEMuWXk8efVOGL/uTHvn0kDHatBN2zQFZH/Mz+/rWCnepv4PfnWIoaYtiCrQoyrN+mg==" });
        }
    }
}
