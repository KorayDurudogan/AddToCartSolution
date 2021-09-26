using Infrastructure.DaoModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    public class StockDataContext : IStockDataContext
    {
        object locker = new object();

        List<StockDao> stockList;

        string stockFilePath;

        public StockDataContext(IWebHostEnvironment hostingEnvironment)
        {
            stockFilePath = Path.Combine(hostingEnvironment.ContentRootPath, "Stock.json");
            string jsonData = File.ReadAllText(stockFilePath);
            stockList = JsonConvert.DeserializeObject<List<StockDao>>(jsonData) ?? new List<StockDao>();
        }

        public Task DecreaseStock(int productId, int amount)
        {
            lock (locker)
            {
                var stock = stockList.FirstOrDefault(s => s.ProductId == productId);
                stock.Amount -= amount;

                string json = JsonConvert.SerializeObject(stockList);

                File.WriteAllText(stockFilePath, json);
                return Task.CompletedTask;
            }
        }

        public Task<int> GetStock(int productId)
        {
            var stock = stockList.FirstOrDefault(s => s.ProductId == productId);
            if (stock != null)
                return Task.FromResult(stock.Amount);

            throw new KeyNotFoundException("Stock info could not found !");
        }
    }
}
