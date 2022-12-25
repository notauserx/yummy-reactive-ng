namespace Rezept.Data.Entities;

public class Instruction
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public string Detail { get; set; }

    public Guid RecipeId { get; set; }
}
