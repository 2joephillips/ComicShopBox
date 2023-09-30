using ComicShop.Core;
using ComicShopBox.Database;
using Newtonsoft.Json;

namespace ComicShopBox.Services;


public interface IComicService
{
    Task<List<Comic>> GetComics();
}

public class ComicService : IComicService
{
    string comicsFolderPath = "comics";
    string jsonFilePath =  Path.Combine(AppContext.BaseDirectory, "Resources\\comicsArchive.json");

    HttpClient client;
    public ComicService()
    {
        client = new HttpClient();
    }

    List<Comic> comicList = new ();

    public async Task<List<Comic>> GetComics()
    {
        if (comicList?.Count > 0) { return comicList; } 
        if(await ComicShopBoxDatabaseService.NumberOfComics() == 0)
        {

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<List<Comic>>(json);
            }
            return new List<Comic>() { new Comic() { FileName ="Test", FilePath="Test"} };
        } else
        {
            comicList = await ComicShopBoxDatabaseService.GetComics();
        }
       
        return comicList ?? new List<Comic>();
    }
}

