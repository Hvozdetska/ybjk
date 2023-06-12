using Katya.Models;

namespace Katya.Helpers
{
    public class ForecastHelper
    {
        private readonly DataHelper _helper;
        private const double _coefficient = 5.9;
        public ForecastHelper(DataHelper helper)
        {
            _helper = helper;
        }

        public async Task<SustainableDevelopmentForecastResponse> CalculateForecastAsync(SustainableDevelopmentForecastRequest forecastRequest)
        {
            var statisticsData = await _helper.GetStatisticsDataAsync();

            if (forecastRequest.GoalId != null)
            {
                statisticsData = statisticsData.Where(s => s.GoalId == (int)forecastRequest.GoalId).ToList();
            }

            var events = statisticsData.SelectMany(s => s.Events).ToList();
            var results = events.Select(r => r.Result).ToList();
            var finansing = events.Select(f => f.Financing).ToList();
            for (int i = 0; i < finansing.Count(); i++)
            {
                finansing[i] = ToUkraineBudget(finansing[i]);
            }

            var averageFinancing = finansing.Sum() / finansing.Count();
            var averageResults = results.Sum() / results.Count();

            var resultForBudget = (averageResults * forecastRequest.Budget.Value) / averageFinancing;
            var monthsNeeded = (int)Math.Round(forecastRequest.DesiredResult.Value/ resultForBudget , MidpointRounding.ToPositiveInfinity);
            monthsNeeded = monthsNeeded > 0 ? monthsNeeded : 1;

            var forecastResult = new SustainableDevelopmentForecastResponse()
            {
                ExpectedResultForOneMonths = resultForBudget,
                NeededMonthsForDesiredResult = monthsNeeded,
                ProposedEvents = events
            };

            return forecastResult;
        }

        private double ToUkraineBudget(double usBudget)
            => usBudget * 36.6 / _coefficient;
    }
}
