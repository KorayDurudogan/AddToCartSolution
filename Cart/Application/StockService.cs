using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        private readonly string _stockApiEndpoint;

        public StockService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _stockApiEndpoint = string.Concat(configuration.GetSection("StockAPI").Value, "stock");
        }

        public async Task<AddCartResponseDto> Call(AddCartRequest addCartDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var stockHttpResponse = await _httpClient.PutAsync(_stockApiEndpoint,
               new StringContent(JsonConvert.SerializeObject(addCartDto), Encoding.UTF8, "application/json"));

            string tokenResponseContent = await stockHttpResponse.Content.ReadAsStringAsync();
         
            if (stockHttpResponse.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AddCartResponseDto>(tokenResponseContent);
         
            throw new Exception(string.Format(CartConstants.ApiCallErrorMessage, tokenResponseContent));
        }
    }
}
