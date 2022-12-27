using CsvHelper;
using System.Globalization;

namespace Rezept.DataLoader;

public class RecipeCsvParser
{
    public ParsedResult GetParsedResult()
    {
        IEnumerable<RecipeItem> records;

        var result = new ParsedResult();
        using (var reader = new StreamReader(".//recipes-small.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            records = csv.GetRecords<RecipeItem>().ToList();

            foreach (var record in records)
            {
                result.HandleRecord(record);
            }
        }

        return result;
    }
}
