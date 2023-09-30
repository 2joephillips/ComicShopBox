using ComicShop.Core;
using Newtonsoft.Json;

namespace ComicShopBox.Services;


public interface IComicService
{
    Task<List<Comic>> GetComics();
}

public interface IAppSettingsService
{
    Task<AppSettings> GetAppSettings();
}

public class AppSettings { 
}

public class AppSettingsService: IAppSettingsService
{

    public async Task<AppSettings> GetAppSettings()
    {
        var jsonFilePath = AppStorageHelper.GetAppSettingsPath();

        return new AppSettings();
    }
}


public class ComicService : IComicService
{

    List<Comic> comicList = new();
    public bool notSetup = false;
    public ComicService()
    {
        AppStorageHelper.LoadSettings();
        //notSetup = AppStorageHelper.AppSetup;
    }
    public async Task<List<Comic>> GetComics()
    {
        if (comicList?.Count > 0) { return comicList; }

        var jsonFilePath = AppStorageHelper.GetAppJsonFilePath();
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Comic>>(json);
        }
        return new List<Comic>() { new Comic() { FileName = "Test", FilePath = "Test" } };

    }
}

