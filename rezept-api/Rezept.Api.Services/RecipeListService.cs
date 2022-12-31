using Microsoft.EntityFrameworkCore;
using Rezept.Data.Contexts;

namespace Rezept.Api.Services;

public class RecipeListService : IRecipeListService
{
    private readonly RezeptDbContext rezeptDbContext;

    public RecipeListService(RezeptDbContext rezeptDbContext)
    {
        this.rezeptDbContext = rezeptDbContext;
    }

    public IEnumerable<RecipeListItem> GetRecipeListItems(RecipeListRequestParams requestParams)
    {

        var recipes = rezeptDbContext.Recipes
                .Include(r => r.Author)
                .Include(r => r.Category)
                .AsQueryable();

        if (!string.IsNullOrWhiteSpace(requestParams.SearchTerm))
        {
            var searchTerm = requestParams.SearchTerm.Trim().ToLower();
            recipes = recipes.Where(r => r.Title != null && r.Title.ToLower().Contains(searchTerm));
        }

        if(!string.IsNullOrWhiteSpace(requestParams.Category))
        {
            recipes = recipes.Where(r => r.Category != null && r.Category.Name == requestParams.Category);
        }

        return // TODO :: use automapper 
            (from recipe in recipes
                .Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize).ToList()
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