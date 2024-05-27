using Newtonsoft.Json;
using YGOPRO.Enums;
using YGOPRO.Models;

namespace YGOPRO;

/// <summary>
/// Represents a YGOPRO API Client
/// </summary>
public class YGOClient
{
    private readonly HttpClient _client;
    private readonly string? _language;

    private const string CardInfoUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
    private const string SetInfoUrl = "https://ygoprodeck.com/api/set-lists/getCardSetsList.php";

    public YGOClient(Language language = Language.English)
    {
        _language = language switch
        {
            Language.English => string.Empty,
            Language.French => "fr",
            Language.German => "de",
            Language.Italian => "it",
            Language.Portuguese => "pt",
            _ => string.Empty
        };
        _client = new HttpClient();
    }

    ~YGOClient()
    {
        _client.Dispose();
    }

    private async Task<T?> GetCardInfoAsync<T>(string? url = null, bool misc = false) where T : class
    {
        var endpoint = CardInfoUrl;
        if (!string.IsNullOrWhiteSpace(_language)) endpoint += $"{_language}&";
        if (misc) endpoint += "misc=yes&";
        endpoint = url != null ? $"{endpoint}&{url}" : endpoint;
        
        var result = await _client.GetAsync(endpoint);
        if (!result.IsSuccessStatusCode)
            return default;
        
        var response = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(response);
    }

    private async Task<T?> GetSetInfoAsync<T>() where T : class
    {
        var result = await _client.GetAsync(SetInfoUrl);
        if (!result.IsSuccessStatusCode)
            return default;

        var response = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(response);
    }

    public async Task<List<Card>?> GetAllCardsAsync(bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>(misc: misc);
        return result?.Data;
    }

    public async Task<Card> GetCardByNameAsync(string name, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"name={name}", misc);
        return result?.Data[0];
    }

    public async Task<List<Card>?> GetCardsByNameAsync(params string[] names) =>
        await GetCardsByNameAsync((IEnumerable<string>)names);

    public async Task<List<Card>?> GetCardsByNameAsync(IEnumerable<string> names, bool misc = false)
    {
        var enumerable = names as string[] ?? names.ToArray();
        var url = enumerable.Length == 1 ? $"name={enumerable.First()}" : $"name={string.Join('|', enumerable)}";
        var result = await GetCardInfoAsync<Cards>(url, misc);

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardByFuzzyNameSearchAsync(string name, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"fname={name}", misc);
        return result?.Data;
    }

    public async Task<Card?> GetCardByIdAsync(int id, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"id={id}", misc);
        return result?.Data?[0];
    }

    public async Task<List<Card>?> GetCardsByTypeAsync(string cardType, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"type={cardType}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByAttackAsync(int attack, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"atk={attack}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByDefenseAsync(int defense, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"def={defense}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByLevelAsync(int level, bool misc = false)
    {
        var result = await GetCardInfoAsync<Cards>($"level={level}", misc);
        return result?.Data;
    }

    public async Task<List<CardSet>> GetAllSetsAsync()
    {
        var result = await GetSetInfoAsync<Sets>();
        return result?.Data;
    }
}