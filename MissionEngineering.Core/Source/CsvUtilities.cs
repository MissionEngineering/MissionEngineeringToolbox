using System.Globalization;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace MissionEngineering.Core;

public static class CsvUtilities
{
    public static bool IsUseMock = false;

    public static void WriteToCsvFile<T>(this IEnumerable<T> records, string fileName)
    {
        if (IsUseMock)
        {
            return;
        }

        using var writer = new StreamWriter(fileName);

        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        var options = new TypeConverterOptions { Formats = ["yyyy-MM-ddTHH:mm:ss.fffZ"] };
        csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

        csvWriter.WriteRecords(records);
    }
}