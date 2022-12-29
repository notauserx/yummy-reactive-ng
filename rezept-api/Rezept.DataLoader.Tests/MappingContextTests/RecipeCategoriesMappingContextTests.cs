namespace Rezept.DataLoader.Tests.MappingContextTests;

public class RecipeCategoriesMappingContextTests
{
    [Fact]
    public void When_new_category_is_given_then_creates_a_new_category_entity()
    {
        var context = new RecipeCategoriesMappingContext();

        context.HandleCategory("new");

        Assert.Single(context.Categories);
    }

    [Fact]
    public void Sets_id_to_created_category_entity()
    {
        var context = new RecipeCategoriesMappingContext();

        var category = context.HandleCategory("new");

        Assert.NotEqual(Guid.Empty, category.Id);
    }

    [Fact]
    public void When_an_existing_category_is_given_then_returns_the_existing_category_entity()
    {
        var context = new RecipeCategoriesMappingContext();

        var category = context.HandleCategory("new");
        var category1 = context.HandleCategory("new");

        Assert.Equal(category.Id, category1.Id);
    }
}
