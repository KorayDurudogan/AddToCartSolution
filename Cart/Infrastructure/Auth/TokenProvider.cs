using Domain;
using Infrastructure.DtoModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Auth
{
    public class TokenProvider : ITokenProvider
    {
        private readonly HttpClient _httpClient;

        private readonly string _stockApiEndpoint;

        private readonly string _stockApiTokenPassword;

        //I am holding the token singleton, since we don't have Redis or any other datasource to keep the token.
        private static string _token;

        public TokenProvider(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _stockApiEndpoint = string.Concat(configuration.GetSection("StockAPI").Value, "token");
            _stockApiTokenPassword = configuration.GetSection("StockAPITokenPassword").Value;
        }

        public async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                var tokenHttpResponse = await _httpClient.PostAsync(_stockApiEndpoint,
                     new StringContent(JsonConvert.SerializeObject(new GetTokenDto(_stockApiTokenPassword)), Encoding.UTF8, "application/json"));

                if (tokenHttpResponse.IsSuccessStatusCode)
                    _token = await tokenHttpResponse.Content.ReadAsStringAsync();
                else
                    throw new Exception("Couldn't get token from StockAPI !");
            }

            return _token;
        }
    }
}
