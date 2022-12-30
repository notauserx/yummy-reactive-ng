namespace Rezept.Api.Services;

public interface IRecipeCategoryService
{
    IEnumerable<RecipeCategoryItem> GetRecipeCategories();
}
