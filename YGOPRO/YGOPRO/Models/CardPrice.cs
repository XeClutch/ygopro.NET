using Newtonsoft.Json;

namespace YGOPRO.Models;

public class CardPrice
{
    [JsonProperty("cardmarket_price")] public double CardmarketPrice { get; private set; }

    [JsonProperty("tcgplayer_price")] public double TCGplayerPrice { get; private set; }

    [JsonProperty("ebay_price")] public double EbayPrice { get; private set; }

    [JsonProperty("amazon_price")] public double AmazongPrice { get; private set; }

    [JsonProperty("coolstuffinc_price")] public double CoolStuffIncPrice { get; private set; }
}