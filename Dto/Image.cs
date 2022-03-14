using System.Text.Json.Serialization;

namespace sfcli.Dto;
public class Image
{
    [JsonPropertyName("data")]
    public string? Data { get; set; }
}