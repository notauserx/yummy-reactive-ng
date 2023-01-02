namespace Rezept.Api.Contracts;

public class RecipeDetailResponse : RecipeListItem
{
    public string AuthorName { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> Steps { get; set; }
    public List<string> AdditionalImageUrls { get; set; }
    public List<string> Keywords { get; set; }
}