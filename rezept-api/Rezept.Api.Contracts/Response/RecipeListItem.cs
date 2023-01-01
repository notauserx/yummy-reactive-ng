namespace Rezept.Api.Contracts;

public class RecipeListItem
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Rating { get; set; }
    public int? Serves { get; set; }
    public string? Category { get; set; }
    public string? imageUrl { get; set; }
    public string? prepTime { get; set; }
    public string? cookTim { get; set; }
}