using Microsoft.EntityFrameworkCore;
using Rezept.Data.Contexts;

namespace Rezept.Api.Services;

public class RecipeDetailService : IRecipeDetailService
{
    private readonly RezeptDbContext rezeptDbContext;

    public RecipeDetailService(RezeptDbContext rezeptDbContext)
    {
        this.rezeptDbContext = rezeptDbContext;
    }

    public async Task<RecipeDetailResponse> GetRecipeDetailAsync(Guid id)
    {
        var recipe = await rezeptDbContext.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)
            .Include(r => r.AdditionalRecipeImageUrls)
            .Include(r => r.RecipeReviews)
            .Include(r => r.Author)
            .Include(r => r.Keywords)
            .Include(r => r.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        if(recipe == null)
        {
            throw new Exception($"No recipe found with id {id}");
        }

        var response = new RecipeDetailResponse();

        response.Id = id;
        response.Title = recipe.Title;
        response.Description = recipe.Description;
        response.Rating = recipe.Rating;
        response.Category = recipe?.Category?.Name;
        response.ImageUrl = recipe?.ImageUrl;
        response.AuthorName = recipe?.Author?.DisplayName ?? string.Empty;
        response.CookTime = recipe?.CookTime;
        response.PrepTime = recipe?.PrepTime;
        response.Serves = recipe?.RecipeServings;
        response.Ingredients = recipe?.Ingredients?
            .Select(i => new RecipeIngredientResponse() { Item = i.Item, Quantity = i.Quantity }).ToList() 
                ?? new List<RecipeIngredientResponse>();
        response.Steps = recipe?.Instructions?.OrderBy(i => i.Number).Select(i => $"Step {i.Number} - {i.Detail}").ToList() ?? new List<string>();
        response.AdditionalImageUrls = recipe?.AdditionalRecipeImageUrls?.Select(x => x.Url ?? string.Empty).ToList() ?? new List<string>();
        response.Keywords = recipe?.Keywords?.Select(k => k.Name ?? string.Empty).ToList() ?? new List<string>();
        
        return response;
    }
}