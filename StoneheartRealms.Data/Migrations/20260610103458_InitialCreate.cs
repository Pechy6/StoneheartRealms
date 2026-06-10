using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dwarves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Energy = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)100),
                    Hunger = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)100),
                    Thirst = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)100),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwarves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dwarves_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Dwarves",
                columns: new[] { "Id", "Age", "Description", "Energy", "Gender", "Hunger", "JobId", "Name", "Thirst" },
                values: new object[,]
                {
                    { 1, 186, "This is the first dwarf", (byte)100, 0, (byte)100, null, "First Dwarf", (byte)100 },
                    { 2, 186, "This is the second dwarf", (byte)100, 1, (byte)100, null, "Second Dwarf", (byte)100 },
                    { 3, 186, "This is the third dwarf", (byte)100, 0, (byte)100, null, "Third Dwarf", (byte)100 },
                    { 4, 186, "This is the fourth dwarf", (byte)100, 0, (byte)100, null, "Fourth Dwarf", (byte)100 },
                    { 5, 186, "This is the fifth dwarf", (byte)100, 1, (byte)100, null, "Fifth Dwarf", (byte)100 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is a farmer", "Farmer" },
                    { 2, "This is a miner", "Miner" },
                    { 3, "This is a cook", "Cook" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dwarves_JobId",
                table: "Dwarves",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dwarves");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
