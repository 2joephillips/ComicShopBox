using System.Net.Http;

namespace ComicShopBox.Services;

public interface IComicVineApiService
{
    Task<bool> CheckApiKey(string apiKey);
}

public class ComicVineApiService : IComicVineApiService
{
    public async Task<bool> CheckApiKey(string apiKey)
    {
        try
        {
            var httpClient = new HttpClient();
            var url = "https://comicvine.gamespot.com/characters/?api_key=97108efe0d3ef7441f7a2954cf2e2e61532758b9&format=json";
            using HttpResponseMessage response = await httpClient.GetAsync(url);
            var x = response.EnsureSuccessStatusCode();
            return x.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }

   
}