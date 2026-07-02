using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameDwarfNeedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hunger",
                table: "Dwarves",
                newName: "Satiety");

            migrationBuilder.RenameColumn(
                name: "Thirst",
                table: "Dwarves",
                newName: "Hydration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Satiety",
                table: "Dwarves",
                newName: "Thirsty");

            migrationBuilder.RenameColumn(
                name: "Hydration",
                table: "Dwarves",
                newName: "Hunger");
        }
    }
}
