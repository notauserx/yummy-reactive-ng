using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class AddNavigationPropertiesOnRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Authors_RecipeAuthorId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeAuthorId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeAuthorId",
                table: "Recipes");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Authors_AuthorId",
                table: "Recipes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Authors_AuthorId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeAuthorId",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeAuthorId",
                table: "Recipes",
                column: "RecipeAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Authors_RecipeAuthorId",
                table: "Recipes",
                column: "RecipeAuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
