using Infrastructure.DaoModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    public class StockEventDataContext : IStockEventDataContext
    {
        List<StockEventDao> stockEventList;

        string stockEventFilePath;

        public StockEventDataContext(IWebHostEnvironment hostingEnvironment)
        {
            stockEventFilePath = Path.Combine(hostingEnvironment.ContentRootPath, "StockEvent.json");
            string jsonData = File.ReadAllText(stockEventFilePath);
            stockEventList = JsonConvert.DeserializeObject<List<StockEventDao>>(jsonData) ?? new List<StockEventDao>();
        }

        public Task Add(StockEventDao stockEventDao)
        {
            stockEventList.Add(stockEventDao);

            string json = JsonConvert.SerializeObject(stockEventList);

            File.WriteAllText(stockEventFilePath, json);

            return Task.CompletedTask;
        }
    }
}
