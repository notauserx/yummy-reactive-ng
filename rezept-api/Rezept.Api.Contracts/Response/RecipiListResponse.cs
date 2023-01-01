namespace Rezept.Api.Contracts;

public record RecipeListResponse(int totalCount, int totalPages, int currentPage, int pageSize, IEnumerable<RecipeListItem> recipes) { };
