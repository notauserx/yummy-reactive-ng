namespace Rezept.Api.Contracts;

public record RecipeListItem
(
    Guid Id, 
    string? Title,
    string? Description,
    int? Rating,
    int? Serves,
    string? Category,
    string? imageUrl,
    string? prepTime,
    string? cookTime
);
