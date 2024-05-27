using Newtonsoft.Json;

namespace YGOPRO.Models;

public class Sets
{
    [JsonProperty("data")] public List<CardSet>? Data { get; private set; }     
}