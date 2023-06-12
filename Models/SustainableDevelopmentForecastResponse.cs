namespace Katya.Models
{
    public class SustainableDevelopmentForecastResponse
    {
        public double ExpectedResultForOneMonths { get; set; }

        public int NeededMonthsForDesiredResult { get; set; }

        public List<Event> ProposedEvents { get; set; }
    }
}
