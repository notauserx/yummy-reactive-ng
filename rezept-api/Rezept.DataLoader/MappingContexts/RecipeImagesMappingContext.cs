namespace Rezept.DataLoader.MappingContexts;

public class RecipeImagesMappingContext
{
    public (string, List<RecipeImageUrl>) HandleImageUrls(Guid recipeId, string images)
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
}
