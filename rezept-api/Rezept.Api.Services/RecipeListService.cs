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

    public IEnumerable<RecipeListItem> GetRecipeListItems()
    {
        var recipes = rezeptDbContext.Recipes
            .Include(r => r.Author)
                .Include(r => r.Category)
                .Where(r => r.ImageUrl != null)
                .Take(90)
                .ToList();

        // TODO :: use automapper
        var result = new List<RecipeListItem>();

        foreach (var recipe in recipes)
        {
            result.Add(new RecipeListItem(
                recipe.Id,
                Title: recipe.Title,
                Description: recipe.Description,
                Rating: recipe.Rating,
                Serves: recipe.RecipeServings,
                Category: recipe?.Category?.Name ?? string.Empty,
                imageUrl: recipe.ImageUrl,
                prepTime: recipe.PrepTime,
                cookTime: recipe.CookTime));
        }

        return result;
    }
}