namespace Rezept.DataLoader.MappingContexts;

public class RecipeCategoriesMappingContext
{
    private Dictionary<string, RecipeCategory> categoriesMap = new();

    public List<RecipeCategory> Categories { get; set; } = new();

    public RecipeCategory HandleCategory(string recipeCategory)
    {
        if (!categoriesMap.ContainsKey(recipeCategory))
        {
            categoriesMap[recipeCategory] = new RecipeCategory()
            {
                Id = Guid.NewGuid(),
                Name = recipeCategory,
            };

            Categories.Add(categoriesMap[recipeCategory]);
        }

        return categoriesMap[recipeCategory];
    }
}
