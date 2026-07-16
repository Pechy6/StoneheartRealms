using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class Time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "GameTimes");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "GameTimes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "GameTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "GameTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GameTimes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Month", "Year" },
                values: new object[] { 9, 786 });
        }
    }
}
