using Newtonsoft.Json;

namespace YGOPRO.Models;

public class ElasticResponse
{
        [JsonProperty("cards")] public List<ElasticCard>? Cards { get; private set; }
        
        [JsonProperty("paging")] public ElasticPaging? Paging { get; private set; }
        
        [JsonProperty("meta")] public ElasticMetadata? Metadata { get; private set; }
}