namespace Rezept.DataLoader;

public class EntityMapperContext
{
    private Dictionary<int, Guid> recipeIdIntToGuid = new();
    private Dictionary<int, RecipeAuthor> authorsMap = new();
    private Dictionary<string, RecipeCategory> categoriesMap = new();

    private Dictionary<string, Keyword> keywordsMap = new();
    public Dictionary<Guid, List<Guid>> RecipeKeywords = new();

    public Dictionary<int, Guid> RecipeIdToGuidMap = new();
    public Dictionary<int, Guid> AuthorIdToGuidMap = new();

    public MappedResult MappedResult { get; private set; } = new();

    public void HandleRecipeItem(RecipeItem item)
    {
        var recipeId = Guid.NewGuid();
        recipeIdIntToGuid[item.RecipeId] = recipeId;

        HandleKeywords(item.Keywords, recipeId);

        var rating = -1;

        int.TryParse(item.AggregatedRating, out rating);

        int reviewCount = -1;
        int.TryParse(item.ReviewCount, out reviewCount);

        var servings = -1;
        int.TryParse(item.RecipeServings, out servings);


        var images = HandleImageUrls(recipeId, item.Images);
        var category = HandleCategory(item.RecipeCategory);
        var author = HandleAuthor(item.AuthorId, item.AuthorName);

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
            NutritionInfo = HandleNutritionInfo(item, recipeId),
            Ingredients = HandleIngredients(item.RecipeIngredientParts, item.RecipeIngredientQuantities, recipeId),
            Instructions = HandleInstructions(item.RecipeInstructions, recipeId),
            AdditionalRecipeImageUrls = images.Item2
        };

        MappedResult.Recipes.Add(recipe);
        MappedResult.NutritionInfos.Add(recipe.NutritionInfo);
    }

    public void HandleReviewItem(ReviewItem item)
    {
        var author = HandleAuthor(item.AuthorId, item.AuthorName);

        var recipeReview = new RecipeReview()
        {
            Id = Guid.NewGuid(),
            RecipeId = recipeIdIntToGuid[item.RecipeId],
            AuthorId = author.Id,
            Review = item.Review,
            Created = item.DateSubmitted,
            Updated = item.DateModified
        };

        MappedResult.RecipeReviews.Add(recipeReview);
    }

    private (string, List<RecipeImageUrl>) HandleImageUrls(Guid recipeId, string images)
    {
        var urls = images.BetweenBrackets();
        string? imageUrl = null;
        List<RecipeImageUrl> additionalUrls = new();
        if (!urls.Contains("http")) urls = null;
        else
        {
            var imageUrls = urls.Split("\",");

            if (imageUrls.Length > 0)
            {
                imageUrl = imageUrls[0].Replace("\"", "").Trim();
            }

            for (int i = 1; i < imageUrls.Length; i++)
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
        return (imageUrl, additionalUrls);
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
            MappedResult.Authors.Add(authorsMap[authorId]);
        }

        return authorsMap[authorId];
    }

    private RecipeCategory HandleCategory(string recipeCategory)
    {
        if (!categoriesMap.ContainsKey(recipeCategory))
        {
            categoriesMap[recipeCategory] = new RecipeCategory()
            {
                Id = Guid.NewGuid(),
                Name = recipeCategory,
            };

            MappedResult.Categories.Add(categoriesMap[recipeCategory]);
        }

        return categoriesMap[recipeCategory];
    }

    public List<Ingredient> HandleIngredients(string itemNames, string itemQuantities, Guid recipeId)
    {
        var result = new List<Ingredient>();
        var ingredientQuantities = itemQuantities.BetweenBrackets().Split(",");
        var ingredientNames = itemNames.BetweenBrackets().Split(",");

        for (var i = 0; i < ingredientNames.Length; i++)
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

    private List<Instruction> HandleInstructions(string instructionsRaw, Guid recipeId)
    {
        var result = new List<Instruction>();
        var instructions = instructionsRaw.BetweenBrackets().Split(",");

        var index = 1;
        foreach (var instruction in instructions)
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

        var values = keywords
            .BetweenBrackets()
            .Split(',');

        foreach (var value in values)
        {
            // Add keyword if new
            if (!keywordsMap.ContainsKey(value))
            {
                keywordsMap[value] = new Keyword()
                {
                    Id = Guid.NewGuid(),
                    Name = value
                };

                MappedResult.Keywords.Add(keywordsMap[value]);
            }

            // associate keyword with recipe
            MappedResult.RecipeKeywords.Add(
                new RecipeKeywords() 
                {
                    Id = Guid.NewGuid(),
                    KeywordId = keywordsMap[value].Id,
                    RecipeId = recipeId
                }
            );
        }

    }
}

