using System.Text.Json;

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