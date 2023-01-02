namespace Rezept.Api.Contracts;

public class RecipeListItem
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Rating { get; set; }
    public int? Serves { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }
    public string? PrepTime { get; set; }
    public string? CookTime { get; set; }
}