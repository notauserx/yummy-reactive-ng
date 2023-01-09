namespace Rezept.DataLoader.MappingContexts;

public class RecipeInstructionsMappingContext
{
    public List<Instruction> HandleInstructions(string instructionsRaw, Guid recipeId)
    {
        var result = new List<Instruction>();
        var instructions = instructionsRaw
            .BetweenBrackets()
            .Split(",")
            .Select(x => x.Replace("\"", ""));

        var index = 1;
        foreach (var instruction in instructions)
        {
            result.Add(new Instruction()
            {
                Id = Guid.NewGuid(),
                Number = index++,
                Detail = instruction,
                RecipeId = recipeId
            });
        }

        return result;
    }
}
