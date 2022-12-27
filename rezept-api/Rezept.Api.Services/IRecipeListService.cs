using Rezept.Api.Contracts;

namespace Rezept.Api.Services
{
    public interface IRecipeListService
    {
        IEnumerable<RecipeListItem> GetRecipeListItems();
    }
}