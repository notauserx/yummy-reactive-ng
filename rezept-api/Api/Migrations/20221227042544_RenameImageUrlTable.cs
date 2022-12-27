using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class RenameImageUrlTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeImageUrl_Recipes_RecipeId",
                table: "RecipeImageUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeImageUrl",
                table: "RecipeImageUrl");

            migrationBuilder.RenameTable(
                name: "RecipeImageUrl",
                newName: "RecipeImageUrls");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeImageUrl_RecipeId",
                table: "RecipeImageUrls",
                newName: "IX_RecipeImageUrls_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeImageUrls",
                table: "RecipeImageUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeImageUrls_Recipes_RecipeId",
                table: "RecipeImageUrls",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeImageUrls_Recipes_RecipeId",
                table: "RecipeImageUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeImageUrls",
                table: "RecipeImageUrls");

            migrationBuilder.RenameTable(
                name: "RecipeImageUrls",
                newName: "RecipeImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeImageUrls_RecipeId",
                table: "RecipeImageUrl",
                newName: "IX_RecipeImageUrl_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeImageUrl",
                table: "RecipeImageUrl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeImageUrl_Recipes_RecipeId",
                table: "RecipeImageUrl",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
