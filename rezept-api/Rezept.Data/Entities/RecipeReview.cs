namespace Rezept.Data.Entities;

public class RecipeReview
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public Guid AuthorId { get; set; }

    public string Review { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public Recipe Recipe { get; set; }

    public RecipeAuthor Author { get; set; }
}
