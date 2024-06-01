using Newtonsoft.Json;

namespace YGOPRO.Models;

public class ElasticMetadata
{
    [JsonProperty("response_time")] public int ResponseTime { get; private set; }
    
    [JsonProperty("cache")] public string Cache { get; private set; }
}