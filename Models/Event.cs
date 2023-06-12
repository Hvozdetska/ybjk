using System.Text.Json.Serialization;

namespace Katya.Models;

public class Event
{
    [JsonPropertyName("eventName")]
    public string EventName { get; set; }

    [JsonPropertyName("financing")]
    public double Financing { get; set; }

    [JsonPropertyName("result")]
    public double Result { get; set; }
}
