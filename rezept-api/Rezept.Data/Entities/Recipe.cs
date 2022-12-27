namespace Rezept.Data.Entities;

public class Recipe
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public Guid AuthorId { get; set; }

    public Guid CategoryId { get; set; }

    public string? PrepTime { get; set; }

    public string? CookTime { get; set; }

    public int? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public string? ImageUrl { get; set; }

    public int? RecipeServings { get; set; }

    public NutritionInfo? NutritionInfo { get; set; }

    public List<Ingredient>? Ingredients { get; set; }

    public List<Instruction>? Instructions { get; set; }

    public List<RecipeImageUrl>? AdditionalRecipeImageUrls { get; set; }
}
