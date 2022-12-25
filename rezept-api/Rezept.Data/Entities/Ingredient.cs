namespace Rezept.Data.Entities;

public class Ingredient
{
    public Guid Id { get; set; }

    public string Item { get; set; }

    public Guid RecipeId { get; set; }
}
