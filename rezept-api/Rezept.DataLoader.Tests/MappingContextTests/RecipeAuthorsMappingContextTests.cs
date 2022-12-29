
namespace Rezept.DataLoader.Tests.MappingContextTests;

public class RecipeAuthorsMappingContextTests
{
    [Fact]
    public void authors_is_empty_initially()
    {
        var authorMappingContext = new RecipeAuthorsMappingContext();

        Assert.Empty(authorMappingContext.Authors);
    }

    [Fact]
    public void authors_is_added_when_new_authorId_is_passed()
    {
        var context = new RecipeAuthorsMappingContext();

        var result = context.HandleAuthor(1, "11");

        Assert.NotNull(result);
        Assert.Single(context.Authors);

    }

    [Fact]
    public void existing_author_is_returned_when_existing_authorId_is_passed()
    {
        var context = new RecipeAuthorsMappingContext();

        var result = context.HandleAuthor(1, "11");
        var result1 = context.HandleAuthor(1, "11");

        Assert.Equal(result.Id, result1.Id);
        Assert.Single(context.Authors);

    }
}
