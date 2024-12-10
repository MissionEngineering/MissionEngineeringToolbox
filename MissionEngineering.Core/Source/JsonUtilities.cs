using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MissionEngineering.Core;

public static class JsonUtilities
{
    public static string ConvertToJsonString<T>(this T obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(obj, options);

        return jsonString;
    }

    public static void WriteToJsonFile<T>(this T obj, string fileName)
    {
        string jsonString = obj.ConvertToJsonString();

        File.WriteAllText(fileName, jsonString);
    }
}
