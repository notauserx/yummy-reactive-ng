namespace Rezept.DataLoader;

public class MappedResult
{
    public List<Recipe> Recipes { get; set; } = new();
    public List<RecipeAuthor> Authors { get; set; } = new();
    public List<RecipeCategory> Categories { get; set; } = new();
    public List<Ingredient> Ingredients { get; set; } = new();
    public List<Instruction> Instructions { get; set; } = new();
    public List<Keyword> Keywords { get; set; } = new();
    public List<RecipeKeywords> RecipeKeywords { get; set; } = new();
    public List<RecipeImageUrl> RecipeImageUrls { get; set; } = new();
    public List<NutritionInfo> NutritionInfos { get; set; } = new();
    public List<RecipeReview> RecipeReviews { get; set; } = new();
}

