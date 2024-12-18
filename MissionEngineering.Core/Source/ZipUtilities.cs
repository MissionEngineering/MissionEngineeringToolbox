﻿using System.IO.Compression;

namespace MissionEngineering.Core;

public static class ZipUtilities
{
    public static bool IsUseMock = false;

    public static void ZipDirectory(string folderPath, string zipFileName)
    {
        if (IsUseMock)
        {
            return;
        }

        var tempPath = Path.GetTempPath();

        var tempFile = Path.GetFileName(zipFileName);

        var tempFileFull = Path.Combine(tempPath, tempFile);

        ZipFile.CreateFromDirectory(folderPath, tempFileFull);

        File.Copy(tempFileFull, zipFileName, true);

        File.Delete(tempFileFull);
    }
}