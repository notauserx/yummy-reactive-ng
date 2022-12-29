namespace Rezept.DataLoader.Tests
{
    public class DummyTests
    {
        [Fact]
        public void ShoouldCreateAuthor()
        {

            var recipe = new RecipeItem(
                RecipeId: 1,
                Name: "recipe",
                AuthorId: 1,
                AuthorName: "author",
                CookTime: "PT35m",
                PrepTime: "PT45m",
                TotalTime: "",
                Description: "description",
                Images: "",
                RecipeCategory: "cat1",
                Keywords: "c(\"Dessert\", \"Low Protein\", \"Low Cholesterol\", \"Healthy\", \"Free Of...\", \"Summer\", \"Weeknight\", \"Freezer\", \"Easy\")",
                RecipeIngredientQuantities: "",
                RecipeIngredientParts:"",
                AggregatedRating: "5",
                ReviewCount: "5",
                Calories: 50,
                FatContent: 40,
                SaturatedFatContent: 10,
                SodiumContent: 1,
                CarbohydrateContent: 4,
                FiberContent: 2,
                SugarContent: 3,
                ProteinContent: 2,
                RecipeServings: "3",
                RecipeYield: "3",
                RecipeInstructions: "c(\"step s\""
                );

        }
    }
}