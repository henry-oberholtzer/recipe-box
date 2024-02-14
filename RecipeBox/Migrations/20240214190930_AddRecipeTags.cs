using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBox.Migrations
{
    public partial class AddRecipeTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTag_Tags_TagId",
                table: "RecipeTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTag",
                table: "RecipeTag");

            migrationBuilder.RenameTable(
                name: "RecipeTag",
                newName: "RecipeTags");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTag_TagId",
                table: "RecipeTags",
                newName: "IX_RecipeTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags",
                column: "RecipeTagId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_RecipeId",
                table: "RecipeTags",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeId",
                table: "RecipeTags",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeId",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTags_RecipeId",
                table: "RecipeTags");

            migrationBuilder.RenameTable(
                name: "RecipeTags",
                newName: "RecipeTag");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTags_TagId",
                table: "RecipeTag",
                newName: "IX_RecipeTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTag",
                table: "RecipeTag",
                column: "RecipeTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTag_Tags_TagId",
                table: "RecipeTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
