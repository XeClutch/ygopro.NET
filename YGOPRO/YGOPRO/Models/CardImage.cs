using Newtonsoft.Json;

namespace YGOPRO.Models;

public class CardImage
{
    [JsonProperty("id")] public int? Id { get; private set; }

    [JsonProperty("image_url")] public string? ImageUrl { get; private set; }

    [JsonProperty("image_url_small")] public string? ImageUrlSmall { get; private set; }

    [JsonProperty("image_url_cropped")] public string? ImageUrlCropped { get; private set; }
}