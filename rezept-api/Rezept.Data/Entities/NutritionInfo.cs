namespace Rezept.Data.Entities;

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

    public Recipe Recipe { get; set; }
}
