using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Data.Migrations
{
    public partial class Subcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryOther",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ContactSubcategory",
                columns: table => new
                {
                    ContactSubcategoryId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactCategoryId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSubcategory", x => x.ContactSubcategoryId);
                    table.ForeignKey(
                        name: "FK_ContactSubcategory_ContactCategories_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "ContactCategories",
                        principalColumn: "ContactCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSubcategory_ContactCategoryId",
                table: "ContactSubcategory",
                column: "ContactCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSubcategory");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryOther",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
