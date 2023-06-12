using System.Text.Json.Serialization;

namespace Katya.Models;

public class Goal
{
    [JsonPropertyName("goalName")]
    public string GoalName { get; set; }

    [JsonPropertyName("events")]
    public List<Event> Events { get; set; }

    [JsonPropertyName("goalId")]
    public int GoalId { get; set; }
}
