using Microsoft.Extensions.Configuration;

namespace StockTests
{
    internal static class TestHelper
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config;
        }
    }
}
