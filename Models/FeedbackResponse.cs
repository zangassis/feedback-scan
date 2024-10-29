using System.Text.Json.Serialization;

namespace FeedbackScan.Models;
public class FeedbackResponse
{
    [JsonPropertyName("sentiment")]
    public string Sentiment { get; set; }

    [JsonPropertyName("mainReason")]
    public string MainReason { get; set; }
}
