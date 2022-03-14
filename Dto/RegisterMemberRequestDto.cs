using System.Text.Json.Serialization;

namespace sfcli.Dto;
public class RegisterMemberRequestDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("images")]
    public List<Image>? Images { get; set; }

    [JsonPropertyName("watchlistIds")]
    public List<string>? WatchlistIds { get; set; }

    [JsonPropertyName("faceDetectorConfig")]
    public FaceDetectorConfig? FaceDetectorConfig { get; set; }

    [JsonPropertyName("faceDetectorResourceId")]
    public string FaceDetectorResourceId { get; set; } = "cpu";

    [JsonPropertyName("templateGeneratorResourceId")]
    public string TemplateGeneratorResourceId { get; set; } = "cpu";

    [JsonPropertyName("keepAutoLearnPhotos")]
    public bool KeepAutoLearnPhotos { get; set; } = false;
}
