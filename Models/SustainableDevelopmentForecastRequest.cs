using Katya.Consts;

namespace Katya.Models;

public class SustainableDevelopmentForecastRequest
{
    public SustainableDevelopmentGoalsEnum? GoalId { get; set; }
    
    public double? Budget { get; set; }

    public double? DesiredResult { get; set; }
}

