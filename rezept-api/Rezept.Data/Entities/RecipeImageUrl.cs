namespace Rezept.Data.Entities;

public class RecipeImageUrl
{
    public Guid Id { get; set; }

    public string? Url { get; set; }

    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}
