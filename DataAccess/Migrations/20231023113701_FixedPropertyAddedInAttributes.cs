using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixedPropertyAddedInAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "CategoryAttributes");

            migrationBuilder.AddColumn<bool>(
                name: "Fixed",
                table: "Attributes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fixed",
                table: "Attributes");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "CategoryAttributes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
