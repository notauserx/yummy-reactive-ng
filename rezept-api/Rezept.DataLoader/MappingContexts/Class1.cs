namespace Rezept.DataLoader.MappingContexts;

public class MappingContext
{
}

public class RecipesMappingContext
{
    private Dictionary<int, Guid> recipeIdIntToGuidMap = new();

}

public class CategoriesMappingContext
{
    private Dictionary<string, RecipeCategory> categoriesMap = new();

}

public class IngredientsMappingContext
{

}

public class RecipeInstructionsMappingContext
{

}

public class RecipeReviewsMappingContext
{

}

public class RecipeKeywordsMappingContext
{

}

public class RecipeImagesMappingContext
{

}
