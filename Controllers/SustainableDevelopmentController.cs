using Katya.Helpers;
using Katya.Models;
using Microsoft.AspNetCore.Mvc;

namespace Katya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SustainableDevelopmentController : Controller
    {
        private readonly ILogger<SustainableDevelopmentController> _logger;
        private readonly ForecastHelper _forecastHelper;
        private readonly DataHelper _dataHelper;

        public SustainableDevelopmentController(ILogger<SustainableDevelopmentController> logger, ForecastHelper forecastHelper, DataHelper dataHelper)
        {
            _forecastHelper = forecastHelper;
            _dataHelper = dataHelper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticData()
        {
            var data = await _dataHelper.GetStatisticsDataAsync();
            return Ok(data.OrderBy(d=>d.GoalId));
        }

        [HttpPost("forecast")]
        public async Task<IActionResult> GetSustainableDevelopmentForecast(SustainableDevelopmentForecastRequest forecastRequest)
        {
            try
            {
                if (forecastRequest.DesiredResult == null || forecastRequest.DesiredResult <= 0 || forecastRequest.DesiredResult > 100)
                {
                    return BadRequest("Invalid DesiredResult");
                }

                if (forecastRequest.Budget == null || forecastRequest.Budget <= 0)
                {
                    return BadRequest("Invalid Budget");
                }

                var result = await _forecastHelper.CalculateForecastAsync(forecastRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
