using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "P_Name",
                table: "Stock",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Stock",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_Name",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Stock");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Stock",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
