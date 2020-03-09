using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreRoutingCodeGen.Subject;
using Newtonsoft.Json;
using Xunit;

namespace AspNetCoreRoutingCodeGen.IntegrationTests.Controllers
{
    [Collection(TestHostCollection.Name)]
    public class WeatherForecastControllerTests
    {
        private readonly HttpClient _appClient;

        public WeatherForecastControllerTests(TestHostFixture appFixture)
        {
            _appClient = appFixture.AppClient;
        }

        [Fact]
        public async Task GET_WeatherForecastMustReturnDataWithTheExpectedShape()
        {
            var response = await _appClient.GetAsync("WeatherForecast");
            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();
            var responseItems = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseText);

            var expectedDates = Enumerable.Range(1, 5).Select(x => DateTime.Now.AddDays(x).Date).ToArray();
            var actualDates = responseItems.Select(item => item.Date).ToArray();
            Assert.Equal(expectedDates, actualDates);

            var actualTemps = responseItems.Select(item => item.TemperatureC);
            Assert.Equal(5, actualTemps.Count());
            Assert.All(actualTemps, temp => Assert.True(temp >= -20 && temp <= 55));

            var validDescs = new [] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var actualDescs = responseItems.Select(item => item.Summary);
            Assert.Equal(5, actualDescs.Count());
            Assert.All(actualDescs, description => Assert.Contains(description, validDescs));
        }
    }
}
