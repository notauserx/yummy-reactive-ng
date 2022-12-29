namespace Rezept.DataLoader;

public record ReviewItem
(
    int ReviewId, 
    int RecipeId, 
    int AuthorId, 
    string AuthorName, 
    string Review, 
    DateTime DateSubmitted, 
    DateTime DateModified
);
