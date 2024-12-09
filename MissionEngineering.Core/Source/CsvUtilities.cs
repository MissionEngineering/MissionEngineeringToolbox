﻿using System.Globalization;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace MissionEngineering.Core;

public static class CsvUtilities
{
    public static void WriteToCsvFile<T>(this IEnumerable<T> records, string fileName)
    {
        using var writer = new StreamWriter(fileName);

        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        var options = new TypeConverterOptions { Formats = ["dd/MM/yyyy HH:mm:ss.fff"] };
        csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

        csvWriter.WriteRecords(records);
    }
}