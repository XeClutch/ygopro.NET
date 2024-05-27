﻿using Newtonsoft.Json;
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

    [JsonProperty("type")] public string Type { get; private set; }
    
    [JsonProperty("frameType")] public string FrameType { get; private set; }

    [JsonProperty("desc")] public string Description { get; private set; }
    
    [JsonProperty("pend_desc")] public string? PendulumEffect { get; private set; }
    
    [JsonProperty("monster_desc")] public string? MonsterEffect { get; private set; }

    [JsonProperty("atk")] public int Attack { get; private set; }

    [JsonProperty("def")] public int Defense { get; private set; }

    [JsonProperty("level")] public int Level { get; private set; }

    [JsonProperty("race")] public string Race { get; private set; }

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
    
    [JsonProperty("misc_info")] public List<MiscInfo> MiscellaneousInfo { get; private set; }
}

public class CardSet
{
    [JsonProperty("set_name")] public string SetName { get; private set; }

    [JsonProperty("set_code")] public string SetCode { get; private set; }

    [JsonProperty("set_rarity")] public string SetRarity { get; private set; }

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
    [JsonProperty("cardmarket_price")] public double CardmarketPrice { get; private set; }

    [JsonProperty("tcgplayer_price")] public double TCGplayerPrice { get; private set; }

    [JsonProperty("ebay_price")] public double EbayPrice { get; private set; }

    [JsonProperty("amazon_price")] public double AmazongPrice { get; private set; }

    [JsonProperty("coolstuffinc_price")] public double CoolStuffIncPrice { get; private set; }
}

public class BanlistInfo
{
    [JsonProperty("ban_tcg")] public string? StatusTCG { get; private set; }
    
    [JsonProperty("ban_ocg")] public string? StatusOCG { get; private set; }
    
    [JsonProperty("ban_goat")] public string? StatusGoat { get; private set; }
}

public class MiscInfo
{
    [JsonProperty("beta_name")] public string? BetaName { get; private set; }
    
    [JsonProperty("views")] public int TotalViews { get; private set; }
    
    [JsonProperty("viewsweek")] public int ViewsThisWeek { get; private set; }
    
    [JsonProperty("upvotes")] public int Upvotes { get; private set; }
    
    [JsonProperty("downvotes")] public int Downvotes { get; private set; }
    
    [JsonProperty("formats")] public List<string> Formats { get; private set; }
    
    [JsonProperty("tcg_date")] public string ReleaseDateTCG { get; private set; }
    
    [JsonProperty("ocg_date")] public string ReleaseDateOCG { get; private set; }
    
    [JsonProperty("konami_id")] public int KonamiId { get; private set; }
    
    [JsonProperty("has_effect")] public int HasEffect { get; private set; }
}