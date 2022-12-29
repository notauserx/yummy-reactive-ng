namespace Rezept.DataLoader.MappingContexts;

public class RecipesMappingContext
{
    private Dictionary<int, Guid> recipeIdIntToGuid = new();

    private RecipeAuthorsMappingContext authorsMappingContext = new();
    private RecipeCategoriesMappingContext categoriesMappingContext = new();
    private RecipeIngredientsMappingContext ingredientsMappingContext = new();
    private RecipeInstructionsMappingContext instructionsMappingContext = new();
    private RecipeImagesMappingContext imagesMappingContext = new();
    private RecipeKeywordsMappingContext keywordsMappingContext = new();
    private RecipeNutritionInfoMappingContext nutritionInfoMappingContext = new();
    private RecipeReviewsMappingContext reviewsMappingContext = new();

    public List<Recipe> Recipes { get; private set; } = new();
    public List<RecipeKeywords> RecipeKeywords => keywordsMappingContext.RecipeKeywords;
    public Guid GetRecipeId(int id) => recipeIdIntToGuid.GetValueOrDefault(id);

    public void HandleRecipeItem(RecipeItem item, List<ReviewItem>? reviewItems)
    {
        var recipeId = Guid.NewGuid();
        recipeIdIntToGuid[item.RecipeId] = recipeId;

        var keywords = keywordsMappingContext.HandleKeywords(item.Keywords, recipeId);

        var rating = -1;

        int.TryParse(item.AggregatedRating, out rating);

        int reviewCount = -1;
        int.TryParse(item.ReviewCount, out reviewCount);

        var servings = -1;
        int.TryParse(item.RecipeServings, out servings);


        var images = imagesMappingContext.HandleImageUrls(recipeId, item.Images);
        var category = categoriesMappingContext.HandleCategory(item.RecipeCategory);
        var author = authorsMappingContext.HandleAuthor(item.AuthorId, item.AuthorName);

        var reviews = reviewsMappingContext.HandleReviews(recipeId, reviewItems, authorsMappingContext);

        var recipe = new Recipe()
        {
            Id = recipeId,
            Title = item.Name,
            Description = item.Description,
            CategoryId = category.Id,
            AuthorId = author.Id,
            PrepTime = item.PrepTime,
            CookTime = item.CookTime,
            Rating = rating == -1 ? null : rating,
            ReviewCount = reviewCount == -1 ? null : reviewCount,
            ImageUrl = images.Item1,
            RecipeServings = servings == -1 ? null : servings,
            Category = category,
            Author = author,
            Keywords = keywords,
            NutritionInfo = nutritionInfoMappingContext.HandleNutritionInfo(item, recipeId),
            Ingredients = ingredientsMappingContext.HandleIngredients(item.RecipeIngredientParts, item.RecipeIngredientQuantities, recipeId),
            Instructions = instructionsMappingContext.HandleInstructions(item.RecipeInstructions, recipeId),
            AdditionalRecipeImageUrls = images.Item2,
            RecipeReviews = reviews,
        };

        Recipes.Add(recipe);
    }
}
