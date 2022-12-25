namespace Rezept.Data.Entities;

public class RecipeAuthor
{
    public Guid Id { get; set; }

    public string? DisplayName { get; set; }

    public List<Recipe>? Recipes { get; set; }
}
