using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rezept.Data.Entities;

namespace Rezept.Data.Contexts;

public class RezeptDbContext : DbContext
{
    public RezeptDbContext(DbContextOptions<RezeptDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // fix to allow sorting on DateTimeOffset when using Sqlite, based on
        // https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            // Sqlite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
            // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
            // use the DateTimeOffsetToBinaryConverter
            // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTimeOffset)
                        || p.PropertyType == typeof(DateTimeOffset?));
                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<RecipeAuthor> Authors { get; set; }

    public DbSet<RecipeCategory> Categories { get; set; }

    public DbSet<Keyword> Keywords { get; set; } 

    public DbSet<RecipeKeywords> RecipeKeywords { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<Instruction> Instructions { get; set; }

    public DbSet<NutritionInfo> NutritionInfos { get; set; }

    public DbSet<RecipeImageUrl> RecipeImageUrls { get; set; }

    public DbSet<RecipeReview> RecipeReviews { get; set; }
}
