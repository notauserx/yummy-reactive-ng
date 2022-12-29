namespace Rezept.DataLoader.MappingContexts;

public class RecipeIngredientsMappingContext
{
    public List<Ingredient> HandleIngredients(string itemNames, string itemQuantities, Guid recipeId)
    {
        var result = new List<Ingredient>();
        var ingredientQuantities = itemQuantities.BetweenBrackets().Split(",");
        var ingredientNames = itemNames.BetweenBrackets().Split(",");

        for (var i = 0; i < ingredientNames.Length; i++)
        {
            if (i >= ingredientQuantities.Length) continue;

            var ingredientDescription = ingredientQuantities[i] + " " + ingredientNames[i];

            result.Add(new Ingredient()
            {
                Id = Guid.NewGuid(),
                Item = ingredientDescription,
                RecipeId = recipeId
            });
        }

        return result;
    }
}
