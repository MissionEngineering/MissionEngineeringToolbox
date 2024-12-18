namespace MissionEngineering.Core;

public static class MockUtilities
{
    public static void SetMock(bool isUseMock)
    {
        CsvUtilities.IsUseMock = isUseMock;
        JsonUtilities.IsUseMock = isUseMock;
        ZipUtilities.IsUseMock = isUseMock;
    }
}
