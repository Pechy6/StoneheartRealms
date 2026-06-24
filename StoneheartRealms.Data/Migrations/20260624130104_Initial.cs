using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is a farmer", "Farmer" },
                    { 2, "This is a fisher", "Fisher" },
                    { 3, "This is a hunter", "Hunter" },
                    { 4, "This is a cook", "Cook" },
                    { 5, "This is a miner", "Miner" },
                    { 6, "This is a blacksmith", "Blacksmith" },
                    { 7, "This is a woodcutter", "Woodcutter" },
                    { 8, "This is a administrator of the colony", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Dwarves",
                columns: new[] { "Id", "Age", "Description", "Energy", "Gender", "Hunger", "JobId", "Name", "Thirst" },
                values: new object[,]
                {
                    { 1, 186, "This is the first dwarf", (byte)100, 0, (byte)100, 1, "First Dwarf", (byte)100 },
                    { 2, 186, "This is the second dwarf", (byte)100, 1, (byte)100, 2, "Second Dwarf", (byte)100 },
                    { 3, 186, "This is the third dwarf", (byte)100, 0, (byte)100, 3, "Third Dwarf", (byte)100 },
                    { 4, 186, "This is the fourth dwarf", (byte)100, 0, (byte)100, 4, "Fourth Dwarf", (byte)100 },
                    { 5, 186, "This is the fifth dwarf", (byte)100, 1, (byte)100, 5, "Fifth Dwarf", (byte)100 },
                    { 6, 186, "This is the sixth dwarf", (byte)100, 0, (byte)100, 6, "Sixth Dwarf", (byte)100 },
                    { 7, 186, "This is the seventh dwarf", (byte)100, 1, (byte)100, 7, "Seventh Dwarf", (byte)100 },
                    { 8, 186, "This is the eighth dwarf", (byte)100, 0, (byte)100, 8, "Eighth Dwarf", (byte)100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dwarves_JobId",
                table: "Dwarves",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_StorageId",
                table: "Resources",
                column: "StorageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dwarves");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
