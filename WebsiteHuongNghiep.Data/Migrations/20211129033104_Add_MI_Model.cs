using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class Add_MI_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MITables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MITables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MITrackers",
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
                    table.PrimaryKey("PK_MITrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MITrackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MIQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MIQuestions_MITables_TableId",
                        column: x => x.TableId,
                        principalTable: "MITables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a01ab883-d923-4c7d-bf6f-42d1592f2280"),
                column: "ConcurrencyStamp",
                value: "154ad415-741e-4c10-95f8-4f434424efb7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef936e2f-d09a-4fdf-8842-459ed6350702"),
                column: "ConcurrencyStamp",
                value: "4732db38-6746-4ca1-867f-464dd486f76f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2"),
                column: "ConcurrencyStamp",
                value: "752dab68-69c9-471d-976c-4c359317ec0c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2e9655-416b-4ff8-9413-1e1d13e0f403"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e74b34c-df7a-4140-a870-2cf392999c2f", "AQAAAAEAACcQAAAAEODuflA8RhnjAHtZYo8Vhl+MR8QS5Ev0Kozf98t1uuOkGvtHCU+zN83OGkHYAOP5gA==" });

            migrationBuilder.CreateIndex(
                name: "IX_MIQuestions_TableId",
                table: "MIQuestions",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_MITrackers_UserId",
                table: "MITrackers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MIQuestions");

            migrationBuilder.DropTable(
                name: "MITrackers");

            migrationBuilder.DropTable(
                name: "MITables");

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
        }
    }
}
