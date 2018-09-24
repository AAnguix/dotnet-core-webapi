namespace Application.FunctionalTests
{
    using Application.Domain;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class ValuesControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public ValuesControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetValues_ReturnsSuccess()
        {
            List<ValueDto> values = new List<ValueDto>()
            {
                new ValueDto { Name = "name", Value = "value" }
            };

            // Act
            var response = await _client.GetAsync(_client.BaseAddress + ApiRoutes.Values);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ValueDto>>(responseString);

            Assert.Equal(result.Count, values.Count);
            Assert.Equal(result[0].Name, values[0].Name);
            Assert.Equal(result[0].Value, values[0].Value);
        }
    }
}
