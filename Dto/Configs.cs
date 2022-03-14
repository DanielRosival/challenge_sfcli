
using System.Text.Json.Serialization;

namespace sfcli.Dto;

public class FaceDetectorConfig
{
    [JsonPropertyName("minFaceSize")]
    public int MinFaceSize { get; set; } = 35;

    [JsonPropertyName("maxFaceSize")]
    public int MaxFaceSize { get; set; } = 600;

    [JsonPropertyName("maxFaces")]
    public int MaxFaces { get; set; } = 20;

    [JsonPropertyName("confidenceThreshold")]
    public int ConfidenceThreshold { get; set; } = 450;
}

public class FaceMaskConfidenceRequest
{
    [JsonPropertyName("faceMaskThreshold")]
    public int FaceMaskThreshold { get; set; } = 3000;
}

public class FaceFeaturesConfig
{
    [JsonPropertyName("age")]
    public bool Age { get; set; } = true;

    [JsonPropertyName("gender")]
    public bool Gender { get; set; } = true;

    [JsonPropertyName("faceMask")]
    public bool FaceMask { get; set; } = true;

    [JsonPropertyName("noseTip")]
    public bool NoseTip { get; set; } = true;

    [JsonPropertyName("yawAngle")]
    public bool YawAngle { get; set; } = true;

    [JsonPropertyName("pitchAngle")]
    public bool PitchAngle { get; set; } = true;

    [JsonPropertyName("rollAngle")]
    public bool RollAngle { get; set; } = true;
}