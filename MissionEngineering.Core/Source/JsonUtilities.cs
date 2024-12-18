using System.Text.Json;

namespace MissionEngineering.Core;

public static class JsonUtilities
{
    public static bool IsUseMock = false;

    public static string ConvertToJsonString<T>(this T obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(obj, options);

        return jsonString;
    }

    public static T ConvertFromJsonString<T>(string jsonString)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        T obj = JsonSerializer.Deserialize<T>(jsonString, options);

        return obj;
    }

    public static void WriteToJsonFile<T>(this T obj, string fileName)
    {
        if (IsUseMock)
        {
            return;
        }

        string jsonString = obj.ConvertToJsonString();

        File.WriteAllText(fileName, jsonString);
    }

    public static T ReadFromJsonFile<T>(string fileName)
    {
        if (IsUseMock)
        {
            return default;
        }

        var jsonString = File.ReadAllText(fileName);

        T obj = ConvertFromJsonString<T>(jsonString);

        return obj;
    }
}