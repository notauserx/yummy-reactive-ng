using Microsoft.EntityFrameworkCore;
using Rezept.DataLoader.MappingContexts;

namespace Rezept.DataLoader;

public class RecipeDataLoader : IDisposable
{

    private readonly RezeptDbContext dbContext;
    private readonly MappingContext mappingContext = new();
    private RecipeDataLoader(RezeptDbContext context)
    {
        dbContext = context;

    }

    public static RecipeDataLoader CreateDefault()
    {
        var dbPath = "..//..//..//..//Api//rezept.db";
        var contextOptions = new DbContextOptionsBuilder<RezeptDbContext>()
            .UseSqlite($"Data Source={dbPath}")
            .EnableSensitiveDataLogging()
            .Options;
        var context = new RezeptDbContext(contextOptions);

        return new RecipeDataLoader(context);
    }

    public void ClearData()
    {
        var sql = @"
            PRAGMA foreign_keys = 0;
            DELETE FROM authors;
            DELETE FROM categories;
            DELETE FROM ingredients;
            DELETE FROM instructions;
            DELETE FROM keywords;
            DELETE FROM nutritioninfos;
            DELETE FROM recipeimageurls;
            DELETE FROM recipekeywords;
            DELETE FROM recipereviews;
            DELETE FROM recipes;
            VACUUM;";
        dbContext.Database.ExecuteSqlRaw(sql);
    }

    public void RunMappings(IEnumerable<RecipeItem> recipeItems, IEnumerable<ReviewItem> reviewItems)
    {
        mappingContext.AddReviewItems(reviewItems);
        mappingContext.UpdateRecipesMappingContext(recipeItems);
    }
    

    public void LoadData()
    {
        dbContext.Recipes.AddRange(mappingContext.Recipes);
        dbContext.RecipeKeywords.AddRange(mappingContext.RecipeKeywords);

        dbContext.SaveChanges();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}
