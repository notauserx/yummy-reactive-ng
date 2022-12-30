using Microsoft.EntityFrameworkCore;
using Rezept.Api.Contracts;
using Rezept.Data.Contexts;

namespace Rezept.Api.Services;

public class RecipeListService : IRecipeListService
{
    private readonly RezeptDbContext rezeptDbContext;

    public RecipeListService(RezeptDbContext rezeptDbContext)
    {
        this.rezeptDbContext = rezeptDbContext;
    }

    public IEnumerable<RecipeListItem> GetRecipeListItems(string? searchTerm)
    {

        var recipes = rezeptDbContext.Recipes
                .Include(r => r.Author)
                .Include(r => r.Category)
                .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim();
            recipes = recipes.Where(r => r.Title != null && r.Title.ToLower().Contains(searchTerm.ToLower()));
        }
        return // TODO :: use automapper 
            (from recipe in recipes.Take(90).ToList()
             select new RecipeListItem(
                recipe.Id,
                Title: recipe.Title,
                Description: recipe.Description,
                Rating: recipe.Rating,
                Serves: recipe.RecipeServings,
                Category: recipe?.Category?.Name ?? string.Empty,
                imageUrl: recipe.ImageUrl,
                prepTime: recipe.PrepTime,
                cookTime: recipe.CookTime)
             );
    }
}