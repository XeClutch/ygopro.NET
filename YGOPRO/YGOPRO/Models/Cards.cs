using Newtonsoft.Json;
using YGOPRO.Enums;

namespace YGOPRO.Models;

public class Cards
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [JsonProperty("data")] public List<Card>? Data { get; private set; }
}

public class Card
{
    [JsonProperty("id")] public int Id { get; private set; }

    [JsonProperty("name")] public string Name { get; private set; }

    [JsonProperty("type")] public CardType Type { get; private set; }

    [JsonProperty("desc")] public string Description { get; private set; }

    [JsonProperty("atk")] public int Attack { get; private set; }

    [JsonProperty("def")] public int Defense { get; private set; }

    [JsonProperty("level")] public int Level { get; private set; }

    [JsonProperty("race")] public CardRace CardRace { get; private set; }

    [JsonProperty("attribute")] public CardAttribute? Attribute { get; private set; }

    [JsonProperty("archetype")] public CardArchetype? Archetype { get; private set; }
    
    [JsonProperty("linkval")] public int? LinkValue { get; private set; }
    
    [JsonProperty("linkmarkers")] public List<CardLinkMarker>? LinkMarkers { get; private set; }

    [JsonProperty("card_sets")] public List<CardSet>? CardSets { get; private set; }

    [JsonProperty("card_images")] public List<CardImage> CardImages { get; private set; }

    [JsonProperty("card_prices")] public List<CardPrice> CardPrices { get; private set; }
}

public class CardSet
{
    [JsonProperty("set_name")] public string SetName { get; private set; }

    [JsonProperty("set_code")] public string SetCode { get; private set; }

    [JsonProperty("set_rarity")] public CardSetRarity SetRarity { get; private set; }

    [JsonProperty("set_rarity_code")] public string SetRarityCode { get; private set; }

    [JsonProperty("set_price")] public double SetPrice { get; private set; }
}

public class CardImage
{
    [JsonProperty("id")] public int Id { get; private set; }

    [JsonProperty("image_url")] public string ImageUrl { get; private set; }

    [JsonProperty("image_url_small")] public string ImageUrlSmall { get; private set; }
}

public class CardPrice
{
    [JsonProperty("cardmarket_price")] public double CardMarketPrice { get; private set; }

    [JsonProperty("tcgplayer_price")] public double TCGplayerPrice { get; private set; }

    [JsonProperty("ebay_price")] public double EbayPrice { get; private set; }

    [JsonProperty("amazon_price")] public double AmazonPrice { get; private set; }

    [JsonProperty("coolstuffinc_price")] public double CoolStuffIncPrice { get; private set; }
}