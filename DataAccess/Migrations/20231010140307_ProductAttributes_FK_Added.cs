using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ProductAttributes_FK_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Attributes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Attributes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
