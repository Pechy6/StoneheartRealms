using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorldTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTimes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameTimes",
                columns: new[] { "Id", "Day", "Hour", "Month", "Year" },
                values: new object[] { 1, 1, 6, 9, 786 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTimes");
        }
    }
}
