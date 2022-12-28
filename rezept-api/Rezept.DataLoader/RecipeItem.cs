namespace Rezept.DataLoader;

public record RecipeItem
(
    int RecipeId,
    string Name,
    int AuthorId,
    string AuthorName,
    string CookTime,
    string PrepTime,
    string TotalTime,
    string Description,
    string Images,
    string RecipeCategory,
    string Keywords,
    string RecipeIngredientQuantities,
    string RecipeIngredientParts,
    string AggregatedRating,
    string ReviewCount,
    decimal Calories,
    decimal FatContent,
    decimal SaturatedFatContent,
    decimal SodiumContent,
    decimal CarbohydrateContent,
    decimal FiberContent,
    decimal SugarContent,
    decimal ProteinContent,
    string RecipeServings,
    string RecipeYield,
    string RecipeInstructions
);


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
