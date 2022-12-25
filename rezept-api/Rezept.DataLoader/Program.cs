// See https://aka.ms/new-console-template for more information

using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Rezept.Data.Contexts;
using Rezept.Data.Entities;
using Rezept.DataLoader;
using System.Globalization;

Console.WriteLine("Hello, World!");

IEnumerable<RecipeItem> records;

var result = new ParsedResult();
using (var reader = new StreamReader(".//recipes-small.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    records = csv.GetRecords<RecipeItem>().ToList();

    foreach (var record in records)
    {
        //Console.WriteLine(record);

        result.HandleRecord(record);
    }
}

var dbPath = "..//..//..//..//Api//rezept.db";
var contextOptions = new DbContextOptionsBuilder<RezeptDbContext>()
    .UseSqlite($"Data Source={dbPath}")
    .EnableSensitiveDataLogging()
    .Options;


var context = new RezeptDbContext(contextOptions);

foreach(var item in result.Authors)
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

    foreach(var recipeKeywordId in item.Value)
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


