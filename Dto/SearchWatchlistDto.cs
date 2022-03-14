using System.Text.Json.Serialization;

namespace sfcli.Dto;
public class SearchWatchlistDto
{
    [JsonPropertyName("image")]
    public Image? Image { get; set; }

    [JsonPropertyName("watchlistIds")]
    public List<string>? WatchlistIds { get; set; }

    [JsonPropertyName("threshold")]
    public int Threshold { get; set; } = 75;

    [JsonPropertyName("maxResultCount")]
    public int MaxResultCount { get; set; } = 1;

    [JsonPropertyName("faceDetectorConfig")]
    public FaceDetectorConfig? FaceDetectorConfig { get; set; }

    [JsonPropertyName("faceDetectorResourceId")]
    public string FaceDetectorResourceId { get; set; } = "cpu";

    [JsonPropertyName("templateGeneratorResourceId")]
    public string? TemplateGeneratorResourceId { get; set; } = "cpu";

    [JsonPropertyName("faceMaskConfidenceRequest")]
    public FaceMaskConfidenceRequest? FaceMaskConfidenceRequest { get; set; }

    [JsonPropertyName("faceFeaturesConfig")]
    public FaceFeaturesConfig? FaceFeaturesConfig { get; set; }
}