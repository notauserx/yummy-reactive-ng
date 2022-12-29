namespace Rezept.DataLoader.MappingContexts;

public class RecipeReviewsMappingContext
{
    public RecipeReview HandleReview(Guid recipeId, RecipeAuthor author, ReviewItem review)
    {
        return new RecipeReview()
        {
            Id = Guid.NewGuid(),
            RecipeId = recipeId,
            Review = review.Review,
            AuthorId = author.Id,
            Created = review.DateSubmitted,
            Updated = review.DateModified,
            Author = author,
        };
    }

    public List<RecipeReview> HandleReviews(Guid recipeId, List<ReviewItem> reviewItems, RecipeAuthorsMappingContext authorsMappingContext)
    {
        List<RecipeReview> result = new();
        
        foreach(var item in reviewItems ?? Enumerable.Empty<ReviewItem>())
        {
            var author = authorsMappingContext.HandleAuthor(item.AuthorId, item.AuthorName);

            result.Add(HandleReview(recipeId, author, item));
        }

        return result;
    }
}
