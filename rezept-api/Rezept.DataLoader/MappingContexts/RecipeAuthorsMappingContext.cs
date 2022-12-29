namespace Rezept.DataLoader.MappingContexts;

public class RecipeAuthorsMappingContext
{
    private Dictionary<int, RecipeAuthor> authorsMap = new();

    public List<RecipeAuthor> Authors => authorsMap.Values.ToList();

    private bool IsNewAuthor(int authorId) => !authorsMap.ContainsKey(authorId);

    private void AddAuthorIfNew(int authorId, string authorName)
    {
        if (IsNewAuthor(authorId))
        {
            authorsMap[authorId] = new RecipeAuthor()
            {
                Id = Guid.NewGuid(),
                DisplayName = authorName,
            };
        }
    }

    public RecipeAuthor HandleAuthor(int authorId, string authorName)
    {
        AddAuthorIfNew(authorId, authorName);
        return authorsMap[authorId];
    }

}
