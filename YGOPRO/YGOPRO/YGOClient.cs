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

    public async Task<List<Card>?> GetCardsByTypeAsync(CardType cardType)
    {
        var stringType = cardType switch
        {
            CardType.EffectMonster => "Effect Monster",
            CardType.FlipEffectMonster => "Flip Effect Monster",
            CardType.FlipTunerEffectMonster => "Flip Tuner Effect Monster",
            CardType.GeminiMonster => "Gemini Monster",
            CardType.NormalMonster => "Normal Monster",
            CardType.NormalTunerMonster => "Normal Tuner Monster",
            CardType.PendulumEffectMonster => "Pendulum Effect Monster",
            CardType.PendulumFlipEffectMonster => "Pendulum Flip Effect Monster",
            CardType.PendulumNormalMonster => "Pendulum Normal Monster",
            CardType.PendulumTunerEffectMonster => "Pendulum Tuner Effect Monster",
            CardType.RitualEffectMonster => "Ritual Effect Monster",
            CardType.RitualMonster => "Ritual Monster",
            CardType.SkillCard => "Skill Card",
            CardType.SpellCard => "Spell Card",
            CardType.SpiritMonster => "Spirit Monster",
            CardType.ToonMonster => "Toon Monster",
            CardType.TrapCard => "Trap Card",
            CardType.TunerMonster => "Tuner Monster",
            CardType.UnionEffectMonster => "Union Effect Monster",
            CardType.FusionMonster => "Fusion Monster",
            CardType.LinkMonster => "Link Monster",
            CardType.PendulumEffectFusionMonster => "Pendulum Effect Fusion Monster",
            CardType.SynchroMonster => "Synchro Monster",
            CardType.SynchroPendulumEffectMonster => "Synchro Pendulum Effect Monster",
            CardType.SynchroTunerMonster => "Synchro Tuner Monster",
            CardType.XYZMonster => "XYZ Monster",
            CardType.XYZPendulumEffectMonster => "XYZ Pendulum Effect Monster",
        };

        var result = await RestGET<Cards>($"type={stringType}");
        return result?.data;
    }

    public async Task<List<Card>?> GetCardsByAttackAsync(int attack)
    {
        var result = await RestGET<Cards>($"atk={attack}");
        return result?.data;
    }
    
    public async Task<List<Card>?> GetCardsByDefenseAsync(int defense)
    {
        var result = await RestGET<Cards>($"def={defense}");
        return result?.data;
    }
    
    public async Task<List<Card>?> GetCardsByLevelAsync(int level)
    {
        var result = await RestGET<Cards>($"level={level}");
        return result?.data;
    } 
}