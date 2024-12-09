using CsvHelper;
using CsvHelper.TypeConversion;
using System.Formats.Asn1;
using System.Globalization;

namespace MissionEngineering.Core.Source;

public static class CsvExtensions
{
    public static void WriteToCsvFile<T>(this IEnumerable<T> records, string fileName)
    {
        using var writer = new StreamWriter(fileName);

        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        var options = new TypeConverterOptions { Formats = ["dd/MM/yyyy hh:mm:ss.fff"] };
        csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

        csvWriter.WriteRecords(records);
    }
}
