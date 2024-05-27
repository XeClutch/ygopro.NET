using Newtonsoft.Json;

namespace YGOPRO.Models;

public class Card
{
    [JsonProperty("id")] public int Id { get; private set; }

    [JsonProperty("name")] public string Name { get; private set; }

    [JsonProperty("treated_as")] public string? TreatedAs { get; private set; }
    
    [JsonProperty("type")] public string Type { get; private set; }
    
    [JsonProperty("frameType")] public string FrameType { get; private set; }

    [JsonProperty("desc")] public string Description { get; private set; }
    
    [JsonProperty("pend_desc")] public string? PendulumEffect { get; private set; }
    
    [JsonProperty("monster_desc")] public string? MonsterEffect { get; private set; }

    [JsonProperty("atk")] public int? Attack { get; private set; }

    [JsonProperty("def")] public int? Defense { get; private set; }

    [JsonProperty("level")] public int? Level { get; private set; }

    [JsonProperty("race")] public string? Race { get; private set; }

    [JsonProperty("attribute")] public string? Attribute { get; private set; }
    
    [JsonProperty("linkval")] public int? LinkValue { get; private set; }
    
    [JsonProperty("linkmarkers")] public List<string>? LinkMarkers { get; private set; }

    [JsonProperty("archetype")] public string? Archetype { get; private set; }
    
    [JsonProperty("banlist_info")] public BanlistInfo? BanlistInfo { get; private set; }
    
    [JsonProperty("scale")] public int? Scale { get; private set; }
    
    [JsonProperty("ygoprodeck_url")] public string? YgoProDeckUrl { get; private set; }

    [JsonProperty("card_sets")] public List<CardSet>? CardSets { get; private set; }

    [JsonProperty("card_images")] public List<CardImage> CardImages { get; private set; }

    [JsonProperty("card_prices")] public List<CardPrice> CardPrices { get; private set; }
    
    [JsonProperty("misc_info")] public List<MiscInfo>? MiscellaneousInfo { get; private set; }
}