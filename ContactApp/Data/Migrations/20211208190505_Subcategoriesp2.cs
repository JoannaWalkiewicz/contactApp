using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Data.Migrations
{
    public partial class Subcategoriesp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactSubcategory_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSubcategory_ContactCategories_ContactCategoryId",
                table: "ContactSubcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactSubcategory",
                table: "ContactSubcategory");

            migrationBuilder.RenameTable(
                name: "ContactSubcategory",
                newName: "ContactSubcategories");

            migrationBuilder.RenameIndex(
                name: "IX_ContactSubcategory_ContactCategoryId",
                table: "ContactSubcategories",
                newName: "IX_ContactSubcategories_ContactCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactSubcategories",
                table: "ContactSubcategories",
                column: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactSubcategories_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId",
                principalTable: "ContactSubcategories",
                principalColumn: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSubcategories_ContactCategories_ContactCategoryId",
                table: "ContactSubcategories",
                column: "ContactCategoryId",
                principalTable: "ContactCategories",
                principalColumn: "ContactCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactSubcategories_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSubcategories_ContactCategories_ContactCategoryId",
                table: "ContactSubcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactSubcategories",
                table: "ContactSubcategories");

            migrationBuilder.RenameTable(
                name: "ContactSubcategories",
                newName: "ContactSubcategory");

            migrationBuilder.RenameIndex(
                name: "IX_ContactSubcategories_ContactCategoryId",
                table: "ContactSubcategory",
                newName: "IX_ContactSubcategory_ContactCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactSubcategory",
                table: "ContactSubcategory",
                column: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactSubcategory_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId",
                principalTable: "ContactSubcategory",
                principalColumn: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSubcategory_ContactCategories_ContactCategoryId",
                table: "ContactSubcategory",
                column: "ContactCategoryId",
                principalTable: "ContactCategories",
                principalColumn: "ContactCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
