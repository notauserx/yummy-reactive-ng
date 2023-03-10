namespace Rezept.Data.Entities;

public class RecipeCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Recipe> Recipes { get; set; }
}
