using CsvHelper;
using System.Globalization;

namespace Rezept.DataLoader;

public class CsvParser<T>
{
    public IEnumerable<T> GetValues(string file) {
        var result = Enumerable.Empty<T>();
        using (var reader = new StreamReader(file))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            result = csv.GetRecords<T>().ToList();
        }

        return result;
    }
}
