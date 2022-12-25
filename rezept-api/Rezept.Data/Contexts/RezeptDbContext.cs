using Microsoft.EntityFrameworkCore;
using Rezept.Data.Entities;

namespace Rezept.Data.Contexts;

public class RezeptDbContext : DbContext
{
    public RezeptDbContext(DbContextOptions<RezeptDbContext> options)
    : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<RecipeAuthor> Authors { get; set; }

    public DbSet<RecipeCategory> Categories { get; set; }

    public DbSet<Keyword> Keywords { get; set; } 

    public DbSet<RecipeKeywords> RecipeKeywords { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<Instruction> Instructions { get; set; }

    public DbSet<NutritionInfo> NutritionInfos { get; set; }
}
