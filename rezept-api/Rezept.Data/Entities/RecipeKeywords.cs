namespace Rezept.Data.Entities;

public class RecipeKeywords
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }
    
    public Guid KeywordId { get; set; }
}
