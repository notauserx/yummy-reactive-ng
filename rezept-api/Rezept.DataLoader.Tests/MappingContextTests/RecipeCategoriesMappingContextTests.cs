namespace Rezept.DataLoader.Tests.MappingContextTests;

public class RecipeCategoriesMappingContextTests
{
    [Fact]
    public void should_add_new_category()
    {
        var context = new RecipeCategoriesMappingContext();

        context.HandleCategory("new");

        Assert.Single(context.Categories);
    }

    [Fact]
    public void should_set_id()
    {
        var context = new RecipeCategoriesMappingContext();

        var category = context.HandleCategory("new");

        Assert.NotEqual(Guid.Empty, category.Id);
    }

    [Fact]
    public void should_not_add_new_category_if_exists()
    {
        var context = new RecipeCategoriesMappingContext();

        var category = context.HandleCategory("new");
        var category1 = context.HandleCategory("new");

        Assert.Equal(category.Id, category1.Id);
    }
}
