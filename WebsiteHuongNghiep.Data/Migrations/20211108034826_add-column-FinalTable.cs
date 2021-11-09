using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class addcolumnFinalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalTable",
                table: "HollandTrackers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalTable",
                table: "HollandTrackers");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "f5c9156f-fb11-44b7-9aff-8f1a9affd137");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "395131ec-9ada-4b26-9e6f-50f55f3c9321");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "3fd0a5b6-a552-4fac-bd25-e0d86954f970");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31125af5-109d-4bf8-9efc-0d7b8439f113", "AQAAAAEAACcQAAAAEMbfa45KYONEIBK6E4R1k+I5ODTvIgvGKjQG/ebWt9CLCHuHbnFHqdWehecicvUjHQ==" });
        }
    }
}
