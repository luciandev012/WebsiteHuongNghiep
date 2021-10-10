using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteHuongNghiep.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HollandResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Table = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollandResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HollandScore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Table = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollandScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HollandTables",
                columns: table => new
                {
                    HLTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollandTables", x => x.HLTableId);
                });

            migrationBuilder.CreateTable(
                name: "HollandTrackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: false),
                    Times = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollandTrackers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HollandMultipleChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HLTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollandMultipleChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HollandMultipleChoices_HollandTables_HLTableId",
                        column: x => x.HLTableId,
                        principalTable: "HollandTables",
                        principalColumn: "HLTableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HollandMultipleChoices_HLTableId",
                table: "HollandMultipleChoices",
                column: "HLTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HollandMultipleChoices");

            migrationBuilder.DropTable(
                name: "HollandResult");

            migrationBuilder.DropTable(
                name: "HollandScore");

            migrationBuilder.DropTable(
                name: "HollandTrackers");

            migrationBuilder.DropTable(
                name: "HollandTables");
        }
    }
}
