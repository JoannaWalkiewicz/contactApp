using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Data.Migrations
{
    public partial class Subcategories2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "ContactSubcategoryId",
                table: "Contacts",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactSubcategory_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId",
                principalTable: "ContactSubcategory",
                principalColumn: "ContactSubcategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactSubcategory_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactSubcategoryId",
                table: "Contacts");
        }
    }
}
