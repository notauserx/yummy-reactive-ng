// See https://aka.ms/new-console-template for more information

using Rezept.DataLoader;

Console.WriteLine("This script will parse the recipes-small.csv and load the parsed result into the rezept.db file in Api project");

Console.WriteLine("Staring to parse the csv file.");
var result = new RecipeCsvParser().GetParsedResult();
Console.WriteLine("Completed Parsing the csv file.");

using (var loader = RecipeDataLoader.CreateDefault(result))
{
    loader.ClearData();
    Console.WriteLine("Cleared the existing data from rezept.db");
    loader.LoadData();
    Console.WriteLine("Data loaded successfully");
}

