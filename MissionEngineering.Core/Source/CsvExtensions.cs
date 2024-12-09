using CsvHelper;
using System.Globalization;

namespace MissionEngineering.Core.Source;

public static class CsvExtensions
{
    public static void WriteToCsvFile<T>(this IEnumerable<T> records, string fileName)
    {
        using var writer = new StreamWriter(fileName);

        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(records);
    }
}
