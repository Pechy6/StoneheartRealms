using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class DwarfState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DwarfState",
                table: "Dwarves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 1,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 2,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 3,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 4,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 5,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 6,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 7,
                column: "DwarfState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dwarves",
                keyColumn: "Id",
                keyValue: 8,
                column: "DwarfState",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DwarfState",
                table: "Dwarves");
        }
    }
}
