using System.Text.Json.Serialization;

namespace sfcli.Dto;
public class CreateWatchlistMemberRequestDto
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }
}