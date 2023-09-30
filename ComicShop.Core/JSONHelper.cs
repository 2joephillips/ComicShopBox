using System.Text.Json;

namespace ComicShop.Core
{
    public static class JSONHelper
    {
        public static List<Comic> Load()
        {

            var filePath = AppStorageHelper.GetAppJsonFilePath();
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var comics = JsonSerializer.Deserialize<List<Comic>>(jsonString);
                return comics;
            }
            return new List<Comic>();
        }

        public static void Save(List<Comic> comics)
        {
            var filePath = AppStorageHelper.GetAppJsonFilePath();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var json = JsonSerializer.Serialize(comics);
            File.WriteAllText(filePath, json);
        }
    }
}
