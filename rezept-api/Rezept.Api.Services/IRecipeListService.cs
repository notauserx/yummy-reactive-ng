using Rezept.Api.Services.Core;

namespace Rezept.Api.Services;

public interface IRecipeListService
{
    PagedList<Recipe> GetRecipeListItems(RecipeListRequestParams requestParams);
}