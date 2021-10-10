using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class SeedingDataIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"), "f5c9156f-fb11-44b7-9aff-8f1a9affd137", "Administrator role", "admin", "admin" },
                    { new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"), "395131ec-9ada-4b26-9e6f-50f55f3c9321", "Role student for person study in university", "student", "student" },
                    { new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"), "3fd0a5b6-a552-4fac-bd25-e0d86954f970", "Role pupil for person study in school (under 18)", "pupil", "pupil" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"), new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DoB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"), 0, "31125af5-109d-4bf8-9efc-0d7b8439f113", new DateTime(1998, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "abcxyz@gmail.com", true, "Anh", "Quang", false, null, "abcxyz@gmail.com", "admin", "AQAAAAEAACcQAAAAEMbfa45KYONEIBK6E4R1k+I5ODTvIgvGKjQG/ebWt9CLCHuHbnFHqdWehecicvUjHQ==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"), new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"));
        }
    }
}
