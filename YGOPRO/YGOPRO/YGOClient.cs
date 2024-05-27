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

    private const string BaseUrl = "https://db.ygoprodeck.com/api";
    private const string ApiVersion = "/v7";
    private const string CardInfo = "/cardinfo.php";

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

    private async Task<T?> RestGET<T>(string? url = null, bool misc = false) where T : class
    {
        var baseurl = $"{BaseUrl}{ApiVersion}{CardInfo}?";
        if (!string.IsNullOrWhiteSpace(_language)) baseurl += $"{_language}&";
        if (misc) baseurl += "misc=yes&";

        baseurl = url != null ? $"{baseurl}&{url}" : baseurl;
        var result = await _client.GetAsync(baseurl);
        if (!result.IsSuccessStatusCode)
            return default;
        var response = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(response);
    }

    public async Task<List<Card>?> GetAllCardsAsync(bool misc = false)
    {
        var result = await RestGET<Cards>(misc: misc);
        return result?.Data;
    }

    public async Task<Card> GetCardByNameAsync(string name, bool misc = false)
    {
        var result = await RestGET<Cards>($"name={name}", misc);
        return result?.Data[0];
    }

    public async Task<List<Card>?> GetCardsByNameAsync(params string[] names) =>
        await GetCardsByNameAsync((IEnumerable<string>)names);

    public async Task<List<Card>?> GetCardsByNameAsync(IEnumerable<string> names, bool misc = false)
    {
        var enumerable = names as string[] ?? names.ToArray();
        var url = enumerable.Length == 1 ? $"name={enumerable.First()}" : $"name={string.Join('|', enumerable)}";
        var result = await RestGET<Cards>(url, misc);

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardByFuzzyNameSearchAsync(string name, bool misc = false)
    {
        var result = await RestGET<Cards>($"fname={name}", misc);
        return result?.Data;
    }

    public async Task<Card?> GetCardByIdAsync(int id, bool misc = false)
    {
        var result = await RestGET<Cards>($"id={id}", misc);
        return result?.Data?[0];
    }

    public async Task<List<Card>?> GetCardsByTypeAsync(string cardType, bool misc = false)
    {
        var result = await RestGET<Cards>($"type={cardType}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByAttackAsync(int attack, bool misc = false)
    {
        var result = await RestGET<Cards>($"atk={attack}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByDefenseAsync(int defense, bool misc = false)
    {
        var result = await RestGET<Cards>($"def={defense}", misc);
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByLevelAsync(int level, bool misc = false)
    {
        var result = await RestGET<Cards>($"level={level}", misc);
        return result?.Data;
    }
}