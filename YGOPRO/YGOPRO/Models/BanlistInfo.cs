using Newtonsoft.Json;

namespace YGOPRO.Models;

public class BanlistInfo
{
    [JsonProperty("ban_tcg")] public string? StatusTCG { get; private set; }
    
    [JsonProperty("ban_ocg")] public string? StatusOCG { get; private set; }
    
    [JsonProperty("ban_goat")] public string? StatusGoat { get; private set; }
}