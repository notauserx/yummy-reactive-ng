using Rezept.Data.Contexts;

namespace Rezept.Api.Services;

public class RecipeCategoryService : IRecipeCategoryService
{
    private readonly RezeptDbContext rezeptDbContext;

    public RecipeCategoryService(RezeptDbContext rezeptDbContext)
    {
        this.rezeptDbContext = rezeptDbContext;
    }

    public IEnumerable<RecipeCategoryItem> GetRecipeCategories()
    {
        return
            from category in rezeptDbContext.Categories
            select new RecipeCategoryItem(category.Name);
    }
}