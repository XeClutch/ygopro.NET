using Newtonsoft.Json;

namespace YGOPRO.Models;

public class MiscInfo
{
    [JsonProperty("beta_id")] public int? BetaId { get; private set; }
    
    [JsonProperty("beta_name")] public string? BetaName { get; private set; }
    
    [JsonProperty("views")] public int TotalViews { get; private set; }
    
    [JsonProperty("viewsweek")] public int ViewsThisWeek { get; private set; }
    
    [JsonProperty("upvotes")] public int Upvotes { get; private set; }
    
    [JsonProperty("downvotes")] public int Downvotes { get; private set; }
    
    [JsonProperty("formats")] public List<string> Formats { get; private set; }
    
    [JsonProperty("tcg_date")] public string? ReleaseDateTCG { get; private set; }
    
    [JsonProperty("ocg_date")] public string? ReleaseDateOCG { get; private set; }
    
    [JsonProperty("konami_id")] public int KonamiId { get; private set; }
    
    [JsonProperty("has_effect")] public int HasEffect { get; private set; }
}