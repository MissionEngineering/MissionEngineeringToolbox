using Serilog;

namespace MissionEngineering.Core;

public class LogUtilities
{
    public static void CreateLogger(string fileName)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }

    public static void CloseLog()
    {
        Log.CloseAndFlush();
    }

    public static void LogInformation(string message, int indentation = 0, params object?[]? propertyValues)
    {
        if (indentation > 0)
        {
            var emptyString = new string(' ', indentation);
            message = emptyString + message;
        }

        Log.Information(message, propertyValues);
    }
}