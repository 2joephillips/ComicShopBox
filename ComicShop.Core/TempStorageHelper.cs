namespace ComicShop.Core
{
    public static class TempStorageHelper
    {
        public static void CleanUpTempFolder(Comic comic)
        {
            var tempFilePath = GetTempFilePath(comic.FilePath);
  
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
            return Path.GetTempPath() + "comicShop\\" + filePath.Split("\\").Last();
        }
    }
}
