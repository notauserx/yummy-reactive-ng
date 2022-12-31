namespace Rezept.Api.Contracts;

public record RecipeListRequestParams
(
    string? SearchTerm,
    string? Category,
    int PageNumber = 1,
    int PageSize = 10
)
{ }
