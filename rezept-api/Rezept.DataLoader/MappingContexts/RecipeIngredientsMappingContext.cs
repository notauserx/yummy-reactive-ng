namespace Rezept.DataLoader.MappingContexts;

public class RecipeIngredientsMappingContext
{
    public List<Ingredient> HandleIngredients(string itemNames, string itemQuantities, Guid recipeId)
    {
        var result = new List<Ingredient>();
        var ingredientQuantities = itemQuantities
            .BetweenBrackets()
            .Split(",")
            .Select(s => s.Replace("\"", ""))
            .ToList();
        
        var ingredientNames = itemNames
            .BetweenBrackets()
            .Split(",")
            .Select(s => s.Replace("\"", ""))
            .ToList();

        for (var i = 0; i < ingredientNames.Count; i++)
        {
            if (i >= ingredientQuantities.Count) continue;

            result.Add(new Ingredient()
            {
                Id = Guid.NewGuid(),
                Quantity = ingredientQuantities[i],
                Item = ingredientNames[i],
                RecipeId = recipeId
            });
        }

        return result;
    }
}