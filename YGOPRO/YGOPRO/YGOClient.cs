using Newtonsoft.Json;
using YGOPRO.Enums;
using YGOPRO.Extensions;
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

    private async Task<T?> RestGET<T>(string? url = null) where T : class
    {
        var baseurl = string.IsNullOrEmpty(_language)
            ? BaseUrl + ApiVersion + CardInfo + "?"
            : $"{BaseUrl}{ApiVersion}{CardInfo}?language={_language}";

        baseurl = url != null ? $"{baseurl}&{url}" : baseurl;
        var result = await _client.GetAsync(baseurl);
        if (!result.IsSuccessStatusCode)
            return default;
        var response = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(response);
    }

    public async Task<List<Card>?> GetAllCardsAsync()
    {
        var result = await RestGET<Cards>();
        return result?.Data;
    }

    public async Task<Card> GetCardByNameAsync(string name)
    {
        var result = await RestGET<Cards>($"name={name}");
        return result?.Data[0];
    }

    public async Task<List<Card>?> GetCardsByNameAsync(params string[] names)
    {
         var url = names.Length == 1 ? $"name={names.First()}" : $"name={string.Join('|', names)}";
         var result = await RestGET<Cards>(url);
 
         return result?.Data;
    }
    public async Task<List<Card>?> GetCardByFuzzyNameSearchAsync(string name)
    {
        var result = await RestGET<Cards>($"fname={name}");
        return result?.Data;
    }

    public async Task<Card?> GetCardByIdAsync(int id)
    {
        var result = await RestGET<Cards>($"id={id}");
        return result?.Data?[0];
    }

    public async Task<List<Card>?> GetCardsByTypeAsync(CardType cardType)
    {
        var cardName = Enum.GetName(cardType)?.UnPascalCase();

        var result = await RestGET<Cards>($"type={cardName}");
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByAttackAsync(int attack)
    {
        var result = await RestGET<Cards>($"atk={attack}");
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByDefenseAsync(int defense)
    {
        var result = await RestGET<Cards>($"def={defense}");
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByLevelAsync(int level)
    {
        var result = await RestGET<Cards>($"level={level}");
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByRaceAsync(params CardRace[] races)
    {
        var stringRaces = EnumListToStrings(races);
        var url = races.Length == 1 ? $"race={stringRaces.First()}" : $"race={string.Join(',', stringRaces)}";
        var result = await RestGET<Cards>(url);
         
        return result?.Data;
    }
    
    public async Task<List<Card>?> GetCardsByAttributeAsync(params CardAttribute[] attributes)
    {
        var stringAttributes = EnumListToStrings(attributes);
        var url = attributes.Length == 1 ? $"attribute={stringAttributes.First()}" : $"attribute={string.Join(',', stringAttributes)}"; 
        var result = await RestGET<Cards>(url);
             
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByLinkValueAsync(int linkValue)
    {
        var result = await RestGET<Cards>($"link={linkValue}");

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByByLinkMarkerAsync(params CardLinkMarker[] linkMarkers)
    {
        var stringMarkers = EnumListToStrings(linkMarkers);
        var url = linkMarkers.Length == 1 ? $"linkmarker={linkMarkers.First()}" : $"linkmarker={string.Join(',', linkMarkers)}"; 
        var result = await RestGET<Cards>(url);
                     
        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByPendulumScaleAsync(int pendulumScale)
    {
        var result = await RestGET<Cards>($"scale={pendulumScale}");

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByArchetypeAsync(CardArchetype archetype)
    {
        var result = await RestGET<Cards>($"archetype={archetype}");

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByBanlistAsync(CardBanList banList)
    {
        var result = await RestGET<Cards>($"banlist={banList}");

        return result?.Data;
    }

    public async Task<List<Card>?> GetCardsByFormatAsync(CardFormat format)
    {
        var stringFormat = Enum.GetName(format)?.UnPascalCase();

        var result = await RestGET<Cards>($"format={stringFormat}");

        return result?.Data;

    }

    private static string[] EnumListToStrings<T>(IReadOnlyList<T> list) where T : struct, Enum
    {
        var toStrings = new string[list.Count];
        for (var i = 0; i < list.Count; i++)
        {
            toStrings[i] = Enum.GetName(list[i])?.UnPascalCase();
        }

        return toStrings;
    }
}