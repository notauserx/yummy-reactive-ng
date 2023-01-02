namespace Rezept.Api.Services;

public interface IRecipeDetailService
{
    Task<RecipeDetailResponse> GetRecipeDetailAsync(Guid id);
}