namespace Rezept.DataLoader.MappingContexts;

public class MappingContext
{
    public RecipesMappingContext RecipesMappingContext { get; private set; } = new();

    private Dictionary<int, List<ReviewItem>> reviewsMapByRecipeId = new();

    public List<Recipe> Recipes => RecipesMappingContext.Recipes;

    public List<RecipeKeywords> RecipeKeywords => RecipesMappingContext.RecipeKeywords;

    public void AddReviewItems(IEnumerable<ReviewItem> recipeReviews)
    {
        reviewsMapByRecipeId = recipeReviews
            .GroupBy(x => x.RecipeId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public void UpdateRecipesMappingContext(IEnumerable<RecipeItem> recipeItems)
    {
        foreach(var item in recipeItems)
        {
            var reviews = reviewsMapByRecipeId.GetValueOrDefault(item.RecipeId);
            RecipesMappingContext.HandleRecipeItem(item, reviews);
        }
    }
}
