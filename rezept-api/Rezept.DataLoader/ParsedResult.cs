using Rezept.Data.Entities;

namespace Rezept.DataLoader;

public class ParsedResult
{
    private Dictionary<int, RecipeAuthor> authorsMap = new();

    public List<RecipeAuthor> AuthorsList => authorsMap.Values.ToList();

    private Dictionary<string, RecipeCategory> categoriesMap = new();

    public List<RecipeCategory> CategoriesList => categoriesMap.Values.ToList();

    public Dictionary<string, Guid> Keywords = new();

    public Dictionary<Guid, List<Guid>> RecipeKeywords = new();
    
    public List<Recipe> Recipes = new();

    public List<NutritionInfo> Nutritions = new();


    public void HandleRecord(RecipeItem item)
    {
        var recipeId = Guid.NewGuid();


        HandleKeywords(item.Keywords, recipeId);

        var rating = -1;

        int.TryParse(item.AggregatedRating, out rating);

        var reviewCount = 0;
        int.TryParse(item.ReviewCount, out reviewCount);

        var servings = -1;
        int.TryParse(item.RecipeServings, out servings);

        List<RecipeImageUrl> additionalUrls = new();

        var urls = BetweenBrackets(item.Images);
        string? imageUrl = null;
        if (!urls.Contains("http")) urls = null;
        else
        {
            var imageUrls = urls.Split("\",");

            if(imageUrls.Length > 0)
            {
                imageUrl = imageUrls[0].Replace("\"", "").Trim();
            }

            for(int i = 1; i < imageUrls.Length; i++)
            {
                var obj = new RecipeImageUrl()
                {
                    Id = Guid.NewGuid(),
                    Url = imageUrls[i].Replace("\"", "").Trim(),
                    RecipeId = recipeId
                };
                additionalUrls.Add(obj);
            }

        }
        var category = HandleCategory(recipeId, item.RecipeCategory);
        var author = HandleAuthor(item.AuthorId, item.AuthorName);

        var recipe = new Recipe()
        {
            Id = recipeId,
            Title = item.Name,
            Description = item.Description,
            AuthorId = author.Id,
            PrepTime = item.PrepTime,
            CookTime = item.CookTime,
            Rating = rating == -1 ? null : rating,
            ReviewCount = reviewCount == -1 ? null : reviewCount,
            ImageUrl = imageUrl,
            RecipeServings = servings == -1 ? null : servings,
            Category = category,
            Author = author,
            NutritionInfo = HandleNutritionInfo(item, recipeId),
            Ingredients = HandleIngredients(item.RecipeIngredientParts, item.RecipeIngredientQuantities, recipeId),
            Instructions = HandleInstructions(item.RecipeInstructions, recipeId),
            AdditionalRecipeImageUrls = additionalUrls
        };

        Recipes.Add(recipe);
        Nutritions.Add(recipe.NutritionInfo);
    }

    private List<Instruction> HandleInstructions(string instructionsRaw, Guid recipeId)
    {
        var result = new List<Instruction>();
        var instructions = BetweenBrackets(instructionsRaw).Split(",");

        var index = 1;
        foreach(var instruction in instructions)
        {
            result.Add(new Instruction()
            {
                Id = Guid.NewGuid(),
                Number = index++,
                Detail = instruction,
                RecipeId = recipeId
            });
        } 

        return result;
    }

    public List<Ingredient> HandleIngredients(string itemNames, string itemQuantities, Guid recipeId)
    {
        var result = new List<Ingredient>();
        var ingredientQuantities = BetweenBrackets(itemQuantities).Split(",");
        var ingredientNames = BetweenBrackets(itemNames).Split(",");

        for(var i = 0; i < ingredientNames.Length; i++)
        {
            if (i >= ingredientQuantities.Length) continue;

            var ingredientDescription = ingredientQuantities[i] + " " + ingredientNames[i];

            result.Add(new Ingredient()
            {
                Id = Guid.NewGuid(),
                Item = ingredientDescription,
                RecipeId = recipeId
            });
        }

        return result;
    }

    private NutritionInfo HandleNutritionInfo(RecipeItem item, Guid recipeId)
    {
        return new NutritionInfo()
        {
            Id = Guid.NewGuid(),
            Calories = item.Calories,
            FatContent = item.FatContent,
            SaturatedFatContent = item.SaturatedFatContent,
            SodiumContent = item.SodiumContent,
            CarbohydrateContent = item.CarbohydrateContent,
            FiberContent = item.FiberContent,
            SugarContent = item.SugarContent,
            ProteinContent = item.ProteinContent,
            RecipeId = recipeId


        };
    }

    private void HandleKeywords(string keywords, Guid recipeId)
    {
        if (keywords == null || keywords == "NA") return;

        var values = BetweenBrackets(keywords)
            .Split(',');

        var recipeKeywordGuids = new List<Guid>();
        foreach(var value in values)
        {
            if (!Keywords.ContainsKey(value))
            {
                Keywords[value] = Guid.NewGuid();
            }

            recipeKeywordGuids.Add(Keywords[value]);
        }

        RecipeKeywords[recipeId] = recipeKeywordGuids;
    }

    private RecipeCategory HandleCategory(Guid recipeId,string recipeCategory)
    {
        if (!categoriesMap.ContainsKey(recipeCategory))
        {
            categoriesMap[recipeCategory] = new RecipeCategory()
            {
                Id = Guid.NewGuid(),
                Name = recipeCategory,
                RecipeId = recipeId
            };
        }

        return categoriesMap[recipeCategory];
    }

    private RecipeAuthor HandleAuthor(int authorId, string authorName)
    {
        if (!authorsMap.ContainsKey(authorId))
        {
            authorsMap[authorId] = new RecipeAuthor()
            {
                Id = Guid.NewGuid(),
                DisplayName = authorName,
            };
        }

        return authorsMap[authorId];
    }

    public string BetweenBrackets(string str) => Between(str, "(", ")");

    public string Between(string STR, string FirstString, string LastString)
    {
        string FinalString;
        int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
        int Pos2 = STR.IndexOf(LastString);

        if (Pos1 < 0 || Pos2 < 0) return String.Empty;
        FinalString = STR.Substring(Pos1, Pos2 - Pos1);
        return FinalString;
    }
}
