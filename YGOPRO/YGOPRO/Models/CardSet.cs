using Newtonsoft.Json;

namespace YGOPRO.Models;

public class CardSet
{
    [JsonProperty("set_name")] public string SetName { get; private set; }

    [JsonProperty("set_code")] public string SetCode { get; private set; }

    [JsonProperty("set_rarity")] public string SetRarity { get; private set; }

    [JsonProperty("set_rarity_code")] public string SetRarityCode { get; private set; }

    [JsonProperty("set_price")] public double SetPrice { get; private set; }
}