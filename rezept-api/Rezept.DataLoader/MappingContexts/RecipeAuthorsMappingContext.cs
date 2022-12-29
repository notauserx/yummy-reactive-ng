namespace Rezept.DataLoader.MappingContexts;

public class RecipeAuthorsMappingContext
{
    private Dictionary<int, RecipeAuthor> authorsMap = new();
    private Dictionary<int, Guid> authorIdToGuidMap = new();

    public Guid GetAuthorGuid(int id) => authorIdToGuidMap.GetValueOrDefault(id);

    public List<RecipeAuthor> Authors => authorsMap.Values.ToList();

    private bool IsNewAuthor(int authorId) => !authorsMap.ContainsKey(authorId);

    private void AddAuthorToContext(int authorId, string authorName) 
    {
        var authorGuid = Guid.NewGuid();
        authorsMap[authorId] = new RecipeAuthor()
        {
            Id = authorGuid,
            DisplayName = authorName,
        };

        authorIdToGuidMap[authorId] = authorGuid;
    }

    private void AddAuthorToContextIfNewAuthor(int authorId, string authorName)
    {
        if (IsNewAuthor(authorId))
        {
            AddAuthorToContext(authorId, authorName);
        }
    }


    private RecipeAuthor GetAuthor(int authorId)
    {
        return authorsMap[authorId];
    }

    public RecipeAuthor GetExistingOrCreatedAuthor(int authorId, string authorName)
    {
        AddAuthorToContextIfNewAuthor(authorId, authorName);
        return GetAuthor(authorId);
    }

}
