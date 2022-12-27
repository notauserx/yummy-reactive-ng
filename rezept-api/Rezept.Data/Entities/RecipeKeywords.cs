namespace Rezept.Data.Entities;

public class RecipeKeywords
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }
    
    public Guid KeywordId { get; set; }

    public Keyword Keyword { get; set; }
}
