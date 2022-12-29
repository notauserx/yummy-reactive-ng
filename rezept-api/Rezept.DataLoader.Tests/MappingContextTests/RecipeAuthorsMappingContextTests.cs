
namespace Rezept.DataLoader.Tests.MappingContextTests;

public class RecipeAuthorsMappingContextTests
{
    [Fact]
    public void Wnen_initialized_then_authors_is_empty()
    {
        var authorMappingContext = new RecipeAuthorsMappingContext();

        Assert.Empty(authorMappingContext.Authors);
    }

    [Fact]
    public void When_new_authorId_is_passed_then_it_adds_a_new_author()
    {
        var context = new RecipeAuthorsMappingContext();

        var result = context.HandleAuthor(1, "11");

        Assert.NotNull(result);
        Assert.Single(context.Authors);

    }

    [Fact]
    public void When_existing_authorId_is_passed_then_an_existing_author_is_returned_()
    {
        var context = new RecipeAuthorsMappingContext();

        var result = context.HandleAuthor(1, "11");
        var result1 = context.HandleAuthor(1, "11");

        Assert.Equal(result.Id, result1.Id);
        Assert.Single(context.Authors);

    }
}
