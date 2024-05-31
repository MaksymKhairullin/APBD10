using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts_CategoriesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Categories_CategoryIdCategories",
                table: "Products_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_Categories_CategoryIdCategories",
                table: "Products_Categories");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategories",
                table: "Products_Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories_FK_category",
                table: "Products_Categories",
                column: "FK_category");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Categories_FK_category",
                table: "Products_Categories",
                column: "FK_category",
                principalTable: "Categories",
                principalColumn: "PK_category",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Categories_FK_category",
                table: "Products_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_Categories_FK_category",
                table: "Products_Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategories",
                table: "Products_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories_CategoryIdCategories",
                table: "Products_Categories",
                column: "CategoryIdCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Categories_CategoryIdCategories",
                table: "Products_Categories",
                column: "CategoryIdCategories",
                principalTable: "Categories",
                principalColumn: "PK_category",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
