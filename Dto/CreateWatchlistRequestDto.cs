using System.Text.Json.Serialization;

namespace sfcli.Dto;
public class CreateWatchlistRequestDto
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }

    [JsonPropertyName("threshold")]
    public int Threshold { get; set; }

    [JsonPropertyName("previewColor")]
    public string? PreviewColor { get; set; }
}