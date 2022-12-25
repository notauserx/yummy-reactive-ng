namespace Rezept.Data.Entities;

public class Recipe
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public Guid AuthorId { get; set; }

    public string? PrepTime { get; set; }

    public string? CookTime { get; set; }

    public RecipeCategory? Category { get; set; }

    public int Rating { get; set; }

    public int ReviewCount { get; set; }

    public string? ImageUrl { get; set; }

    public string? RecipeServings { get; set; }

    public NutritionInfo? NutritionInfo { get; set; }

    public List<Ingredient>? Ingredients { get; set; }

    public List<Instruction>? Instructions { get; set; }

}

public class RecipeAuthor
{
    public Guid Id { get; set; }

    public string? DisplayName { get; set; }

    public List<Recipe>? Recipes { get; set; }
}

public class RecipeCategory
{
    public Guid Id { get; set; }

    public int Name { get; set; }
}

public class RecipeKeywords
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }
    
    public Guid KeywordId { get; set; }
}

public class Keyword
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
}

public class Ingredient
{
    public Guid Id { get; set; }

    public string? Item { get; set; }

    public Guid RecipeId { get; set; }
}

public class Instruction
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public int Detail { get; set; }

    public Guid RecipeId { get; set; }
}

public class NutritionInfo
{
    public Guid Id { get; set; }
    
    public decimal Calories { get; set; }
    
    public decimal FatContent { get; set; }
    
    public decimal SaturatedFatContent { get; set; }
    
    public decimal SodiumContent { get; set; }
    
    public decimal CarbohydrateContent { get; set; }
    
    public decimal FiberContent { get; set; }
    
    public decimal SugarContent { get; set; }
 
    public decimal ProteinContent { get; set; }

    public Guid RecipeId { get; set; }
}
