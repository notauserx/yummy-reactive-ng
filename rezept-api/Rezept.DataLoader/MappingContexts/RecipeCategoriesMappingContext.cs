namespace Rezept.DataLoader.MappingContexts;

public class RecipeCategoriesMappingContext
{
    private Dictionary<string, RecipeCategory> categoriesMap = new();

    public List<RecipeCategory> Categories => categoriesMap.Values.ToList();

    public RecipeCategory HandleCategory(string recipeCategory)
    {
        AddCategoryIfNew(recipeCategory);

        return categoriesMap[recipeCategory];
    }

    private bool IsNewCategory(string category) => !categoriesMap.ContainsKey(category);

    private void AddCategoryIfNew(string category)
    {
        if (IsNewCategory(category))
        {
            categoriesMap[category] = new RecipeCategory()
            {
                Id = Guid.NewGuid(),
                Name = category,
            };
        }
    }

}
