namespace ComicShop.Core;

public static class TempStorageHelper
{
    public static void CleanUpTempFolder(string tempFolderPath)
    {
        if (Directory.Exists(tempFolderPath))
            Directory.Delete(tempFolderPath, true);
    }

    public static string SetUpTempFolder(string filePath)
    {
        var tempFilePath = GetTempFilePath(filePath);
        if (Directory.Exists(tempFilePath))
            Directory.Delete(tempFilePath, true);

        Directory.CreateDirectory(tempFilePath);

        return tempFilePath;
    }

    static string GetTempFilePath(string filePath)
    {
        return $"{AppStorageHelper.GetAppPath()}{filePath.Split("\\").Last()}";
    }
}