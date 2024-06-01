using Newtonsoft.Json;

namespace YGOPRO.Models;

public class ElasticPaging
{
    [JsonProperty("current_rows")] public int CurrentRows { get; private set; }
    
    [JsonProperty("total_rows")] public int TotalRows { get; private set; }
    
    [JsonProperty("rows_remaining")] public int RowsRemaining { get; private set; }
    
    [JsonProperty("total_pages")] public int TotalPages { get; private set; }
    
    [JsonProperty("pages_remaining")] public int PagesRemaining { get; private set; }
}