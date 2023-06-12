using Katya.Models;
using System.Text.Json;

namespace Katya.Helpers
{
    public class DataHelper
    {
        public async Task<List<Goal>> GetStatisticsDataAsync()
        {
            using (StreamReader sr = new StreamReader($"{Environment.CurrentDirectory}\\Data\\Events.json"))
            {
                string jsonString = await sr.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<Goal>>(jsonString) ?? new List<Goal>();
            }
        }

    }
}
