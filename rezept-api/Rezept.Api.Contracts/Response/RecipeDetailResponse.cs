namespace Rezept.Api.Contracts;

public class RecipeDetailResponse : RecipeListItem
{
    public string AuthorName { get; set; }
    public List<RecipeIngredientResponse> Ingredients { get; set; }
    public List<RecipeStepResponse> Steps { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<string> Keywords { get; set; }
}
