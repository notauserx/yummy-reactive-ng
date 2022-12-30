namespace Rezept.Api.Contracts;

public record RecipeListRequestParams
(
    string? SearchTerm,
    string? Category
)
{ }
