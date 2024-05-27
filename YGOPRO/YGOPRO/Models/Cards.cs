using Newtonsoft.Json;
using YGOPRO.Enums;

namespace YGOPRO.Models;

public class Cards
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    [JsonProperty("data")] public List<Card>? Data { get; private set; }
}