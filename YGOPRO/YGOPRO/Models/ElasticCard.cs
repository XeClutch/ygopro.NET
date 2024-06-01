using Newtonsoft.Json;

namespace YGOPRO.Models;

public class ElasticCard
{
    [JsonProperty("id")] public int Id { get; private set; }
    
    [JsonProperty("name")] public string Name { get; private set; }
    
    [JsonProperty("desc")] public string Description { get; private set; }
    
    [JsonProperty("type")] public string Type { get; private set; }
    
    [JsonProperty("race")] public string Race { get; private set; }
    
    [JsonProperty("attribute")] public string? Attribute { get; private set; }
    
    [JsonProperty("atk")] public int? Attack { get; private set; }
    
    [JsonProperty("def")] public int? Defense { get; private set; }
    
    [JsonProperty("tcg_date")] public string ReleaseDateTCG { get; private set; }
    
    [JsonProperty("ocg_date")] public string ReleaseDateOCG { get; private set; }
    
    [JsonProperty("pretty_url")] public string PrettyURL { get; private set; }
}