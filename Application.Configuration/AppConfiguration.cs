namespace Application.Configuration
{
    using Microsoft.Extensions.Configuration;

    public class AppConfiguration
    {
        private readonly IConfigurationRoot _configuration;

        public AppConfiguration(string filePath, bool optional, bool reloadOnChange)
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(filePath, optional, reloadOnChange)
                .Build();
        }

        public string GetConnectionString() => _configuration["Data:ConnectionString"];
    }
}
