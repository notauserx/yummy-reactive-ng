using Microsoft.EntityFrameworkCore;
using Rezept.Api.Services.Core;
using Rezept.Data.Contexts;

namespace Rezept.Api.Services;

public class RecipeListService : IRecipeListService
{
    private readonly RezeptDbContext rezeptDbContext;

    public RecipeListService(RezeptDbContext rezeptDbContext)
    {
        this.rezeptDbContext = rezeptDbContext;
    }

    public PagedList<Recipe> GetRecipeListItems(RecipeListRequestParams requestParams)
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

        return PagedList<Recipe>.Create(
            recipes,
            requestParams.PageNumber,
            requestParams.PageSize);
    }
}