namespace Rezept.DataLoader.MappingContexts;

public class RecipeKeywordsMappingContext
{
    private Dictionary<string, Keyword> keywordsMap = new();

    public List<Keyword> Keywords => keywordsMap.Values.ToList();

    public List<RecipeKeywords> RecipeKeywords = new();

    public List<Keyword> HandleKeywords(string keywords, Guid recipeId)
    {
        List<Keyword> result = new();
        if (keywords == null || keywords == "NA") return result;

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

            }

            result.Add(keywordsMap[value]);

            // associate keyword with recipe
            RecipeKeywords.Add(
                new RecipeKeywords()
                {
                    Id = Guid.NewGuid(),
                    KeywordId = keywordsMap[value].Id,
                    RecipeId = recipeId
                }
            );
        }

        return result;
    }
}
