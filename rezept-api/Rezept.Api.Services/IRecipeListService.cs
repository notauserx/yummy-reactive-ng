namespace Rezept.Api.Services;

public interface IRecipeListService
{
    IEnumerable<RecipeListItem> GetRecipeListItems(string? searchTerm);
}