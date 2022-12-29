// See https://aka.ms/new-console-template for more information

using Rezept.DataLoader;

Console.WriteLine("This script will parse the recipes-small.csv and load the parsed result into the rezept.db file in Api project");

Console.WriteLine("Staring to parse the recipes-small.csv file.");
var recipeItems = new CsvParser<RecipeItem>().GetValues(".//recipes-small.csv");
Console.WriteLine("Completed Parsing the recipes-small.csv file.");

Console.WriteLine("Staring to parse the reviews-small.csv file.");
var reviewItems = new CsvParser<ReviewItem>().GetValues(".//reviews-small.csv");
Console.WriteLine("Completed Parsing the reviews-small.csv file.");



using (var loader = RecipeDataLoader.CreateDefault())
{
    loader.ClearData();
    Console.WriteLine("Cleared the existing data from rezept.db");

    Console.WriteLine("Starting the mappings...");
    loader.RunMappings(recipeItems, reviewItems);
    Console.WriteLine("Mappings completed successfully");

    loader.LoadData();
    Console.WriteLine("Data loaded successfully");
}

