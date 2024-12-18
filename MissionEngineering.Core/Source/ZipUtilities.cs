using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Core;

public static class ZipUtilities
{
    public static void ZipDirectory(string folderPath, string zipFileName)
    {
        var tempPath = Path.GetTempPath();

        var tempFile = Path.GetFileName(zipFileName);

        var tempFileFull = Path.Combine(tempPath, tempFile);

        ZipFile.CreateFromDirectory(folderPath, tempFileFull);

        File.Copy(tempFileFull, zipFileName, true);

        File.Delete(tempFileFull);
    }
}