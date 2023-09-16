using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightHeight.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BookStores",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "BookID",
                keyValue: 1,
                columns: new[] { "Quantity", "TotalPrice" },
                values: new object[] { 0, 0m });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "BookID",
                keyValue: 2,
                columns: new[] { "Quantity", "TotalPrice" },
                values: new object[] { 0, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BookStores");
        }
    }
}
