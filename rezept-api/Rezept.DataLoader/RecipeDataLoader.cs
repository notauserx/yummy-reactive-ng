using Microsoft.EntityFrameworkCore;
using Rezept.Data.Contexts;
using Rezept.Data.Entities;

namespace Rezept.DataLoader;

public class RecipeDataLoader : IDisposable
{
    private readonly ParsedResult result;

    private readonly RezeptDbContext context;
    private RecipeDataLoader(RezeptDbContext context, ParsedResult result)
    {
        this.context = context;
        this.result = result;

    }

    public static RecipeDataLoader CreateDefault(ParsedResult result)
    {
        var dbPath = "..//..//..//..//Api//rezept.db";
        var contextOptions = new DbContextOptionsBuilder<RezeptDbContext>()
            .UseSqlite($"Data Source={dbPath}")
            .EnableSensitiveDataLogging()
            .Options;
        var context = new RezeptDbContext(contextOptions);

        return new RecipeDataLoader(context, result);
    }

    public void ClearData()
    {
        var sql = @"
            DELETE FROM authors;
            DELETE FROM categories;
            DELETE FROM ingredients;
            DELETE FROM instructions;
            DELETE FROM keywords;
            DELETE FROM nutritioninfos;
            DELETE FROM recipeimageurls;
            DELETE FROM recipekeywords;
            DELETE FROM recipes;";
        context.Database.ExecuteSqlRaw(sql);
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public void LoadData()
    {
        foreach (var item in result.Authors)
        {
            context.Authors.Add(new RecipeAuthor()
            {
                Id = item.Value,
                DisplayName = item.Key
            });
        }
        context.SaveChanges();

        foreach (var item in result.Categories)
        {
            context.Categories.Add(new RecipeCategory()
            {
                Id = item.Value,
                Name = item.Key
            });
        }
        context.SaveChanges();

        foreach (var item in result.Keywords)
        {
            context.Keywords.Add(new Keyword()
            {
                Id = item.Value,
                Name = item.Key
            });
        }
        context.SaveChanges();


        foreach (var recipe in result.Recipes)
        {
            context.Recipes.Add(recipe);
        }

        context.SaveChanges();


        foreach (var item in result.RecipeKeywords)
        {
            var rKeys = new List<RecipeKeywords>();
            var recipeId = item.Key;

            foreach (var recipeKeywordId in item.Value)
            {
                rKeys.Add(new RecipeKeywords()
                {
                    Id = Guid.NewGuid(),
                    KeywordId = recipeKeywordId,
                    RecipeId = recipeId
                });
            }
            context.RecipeKeywords.AddRange(rKeys);
        }

        context.SaveChanges();
    }
}
