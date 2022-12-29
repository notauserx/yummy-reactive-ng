namespace Rezept.DataLoader.MappingContexts;

public class RecipeNutritionInfoMappingContext
{
    public List<NutritionInfo> NutritionInfos { get; private set; } = new();
    public NutritionInfo HandleNutritionInfo(RecipeItem item, Guid recipeId)
    {
        var nutritionInfo = new NutritionInfo()
        {
            Id = Guid.NewGuid(),
            Calories = item.Calories,
            FatContent = item.FatContent,
            SaturatedFatContent = item.SaturatedFatContent,
            SodiumContent = item.SodiumContent,
            CarbohydrateContent = item.CarbohydrateContent,
            FiberContent = item.FiberContent,
            SugarContent = item.SugarContent,
            ProteinContent = item.ProteinContent,
            RecipeId = recipeId
        };

        NutritionInfos.Add(nutritionInfo);

        return nutritionInfo;
    }
}
