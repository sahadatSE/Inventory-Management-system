using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable
namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Suppliers\" ALTER COLUMN \"S_Id\" TYPE integer USING \"S_Id\"::integer;"
            );
            migrationBuilder.AddColumn<string>(
                name: "S_Email",
                table: "Suppliers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "S_Email",
                table: "Suppliers");
            migrationBuilder.AlterColumn<string>(
                name: "S_Id",
                table: "Suppliers",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 128)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}