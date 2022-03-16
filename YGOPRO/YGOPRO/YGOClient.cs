using Newtonsoft.Json;
using YGOPRO.Models;

namespace YGOPRO;

/// <summary>
/// Represents a YGOPRO API Client
/// </summary>
public class YGOClient
{
    private HttpClient _client;

    public YGOClient() => _client =
        new HttpClient();

    ~YGOClient()
    {
        _client.Dispose();
    }

    private async Task<T?> RestGET<T>(string? url = null) where T : class
    {
        
        var baseurl = url != null ? $"https://db.ygoprodeck.com/api/v7/cardinfo.php?{url}" : "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        var result = await _client.GetAsync(baseurl);
        if (!result.IsSuccessStatusCode) 
            return default;
        var response = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(response);

    }

    public async Task<List<Card>?> GetAllCardsAsync()
    {
        var result = await RestGET<Cards>();

        return result?.data;
    }

    public async Task<Card?> GetCardByNameAsync(string name)
    {
        var result = await RestGET<Cards>($"name={name}");

        var card = result?.data[0];
        return card;

    }
}