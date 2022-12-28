namespace Rezept.DataLoader;

public class EntityMapperController
{
    private readonly EntityMapperContext mapperContext;
    private readonly RezeptDbContext dbContext;

    public EntityMapperController(RezeptDbContext context)
    {
        this.dbContext = context;
        mapperContext = new();
    }

    public void MapAndSaveChanges(IEnumerable<RecipeItem> recipeItems, IEnumerable<ReviewItem> reviewItems)
    {
        ProcessRecipeItems(recipeItems);

        ProcessReviewItems(reviewItems);

        UpdateAndSaveDbContext();
    }

    private void UpdateAndSaveDbContext()
    {
        dbContext.Categories.AddRange(mapperContext.MappedResult.Categories);
        dbContext.Authors.AddRange(mapperContext.MappedResult.Authors);

        dbContext.Recipes.AddRange(mapperContext.MappedResult.Recipes);

        dbContext.Keywords.AddRange(mapperContext.MappedResult.Keywords);
        dbContext.RecipeKeywords.AddRange(mapperContext.MappedResult.RecipeKeywords);

        dbContext.RecipeReviews.AddRange(mapperContext.MappedResult.RecipeReviews);

        dbContext.SaveChanges();
    }

    private void ProcessRecipeItems(IEnumerable<RecipeItem> recipeItems)
    {
        foreach (var item in recipeItems)
        {
            mapperContext.HandleRecipeItem(item);
        }
    }

    private void ProcessReviewItems(IEnumerable<ReviewItem> reviewItems)
    {
        foreach(var review in reviewItems)
        {

        }
    }
}