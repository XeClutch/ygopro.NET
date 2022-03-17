using Newtonsoft.Json;
using YGOPRO.Enums;
using YGOPRO.Models;
using Type = YGOPRO.Enums.Type;

namespace YGOPRO;

/// <summary>
/// Represents a YGOPRO API Client
/// </summary>
public class YGOClient
{
    private readonly HttpClient _client;
    private readonly string? _language;

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
            ? "https://db.ygoprodeck.com/api/v7/cardinfo.php?"
            : $"https://db.ygoprodeck.com/api/v7/cardinfo.php?language={_language}";

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

        return result?.data;
    }

    public async Task<Card?> GetCardByNameAsync(string name)
    {
        var result = await RestGET<Cards>($"name={name}");
        return result?.data[0];
    }
    public async Task<List<Card>?> GetCardsByNameAsync(string[] names)
    {
        var url = names.Length == 1 ? $"name={names[0]}" : $"name={string.Join('|', names)}";
        var result = await RestGET<Cards>(url);

        return result?.data;
    }

    public async Task<List<Card>?> FuzzySearchByNameAsync(string name)
    {
        var result = await RestGET<Cards>($"fname={name}");
        return result?.data;
    }
    
    public async Task<Card?> GetCardByIdAsync(int id)
    { 
        var result = await RestGET<Cards>($"id={id}");
        return result?.data[0];
    }

    public async Task<List<Card?>> GetCardsByTypeAsync(Type type)
    {
        var stringType = type switch
        {
            Type.EffectMonster => "Effect Monster",
            Type.FlipEffectMonster => "Flip Effect Monster",
            Type.FlipTunerEffectMonster => "Flip Tuner Effect Monster",
            Type.GeminiMonster => "Gemini Monster",
            Type.NormalMonster => "Normal Monster",
            Type.NormalTunerMonster => "Normal Tuner Monster",
            Type.PendulumEffectMonster => "Pendulum Effect Monster",
            Type.PendulumFlipEffectMonster => "Pendulum Flip Effect Monster",
            Type.PendulumNormalMonster => "Pendulum Normal Monster",
            Type.PendulumTunerEffectMonster => "Pendulum Tuner Effect Monster",
            Type.RitualEffectMonster => "Ritual Effect Monster",
            Type.RitualMonster => "Ritual Monster",
            Type.SkillCard => "Skill Card",
            Type.SpellCard => "Spell Card",
            Type.SpiritMonster => "Spirit Monster",
            Type.ToonMonster => "Toon Monster",
            Type.TrapCard => "Trap Card",
            Type.TunerMonster => "Tuner Monster",
            Type.UnionEffectMonster => "Union Effect Monster",
        };

        var result = await RestGET<Cards>($"type={stringType}");
        return result?.data;
    }
}