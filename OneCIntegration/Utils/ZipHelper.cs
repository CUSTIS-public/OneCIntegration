using System.ComponentModel;
using System.IO.Compression;

namespace OneCIntegration.Utils;

public class ZipHelper
{
    public static List<string> GetFileNames(string directory, string baseName)
    {
        var files = new List<string>();
        var partNumber = 1;
        while (true)
        {
            var partFile = Path.Combine(directory, $"{baseName}.{partNumber:D3}");
            if (!File.Exists(partFile)) break;
            files.Add(partFile);
            partNumber++;
        }
        return files;
    }

    public static void Combine(string directory, string baseName, string outputFile)
    {
        var inputFiles = GetFileNames(directory, baseName);
        Combine(inputFiles, outputFile);
    }

    public static void Combine(List<string> inputFiles, string outputFile)
    {
        using var outputStream = File.Create(outputFile);
        foreach (var file in inputFiles)
        {
            using var inputStream = File.OpenRead(file);
            {
                inputStream.CopyTo(outputStream);
            }
        }
    }

    public static void ExtractToDirectory(string directory, string baseName, string outputFile, string extractPath)
    {
        Combine(directory, baseName, outputFile);
        ZipFile.ExtractToDirectory(outputFile, extractPath);
    }

    public static void ExtractToDirectory(List<string> inputFiles, string outputFile, string extractPath)
    {
        if (inputFiles.Count == 1)
        {
            ZipFile.ExtractToDirectory(inputFiles[0], extractPath);
        }
        else
        {
            Combine(inputFiles, outputFile);
            ZipFile.ExtractToDirectory(outputFile, extractPath);
        }
    }
}