using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneheartRealms.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWaterResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Water" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Amount", "ResourceTypeId", "StorageId" },
                values: new object[] { 9, 10000, 9, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
