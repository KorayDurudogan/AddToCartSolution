using Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    public class CartDataContext : ICartDataContext
    {
        List<CartDao> cartItemList;

        string cartItemFilePath;

        public CartDataContext(IWebHostEnvironment hostingEnvironment)
        {
            cartItemFilePath = Path.Combine(hostingEnvironment.ContentRootPath, "CartItem.json");
            string jsonData = File.ReadAllText(cartItemFilePath);
            cartItemList = JsonConvert.DeserializeObject<List<CartDao>>(jsonData) ?? new List<CartDao>();
        }

        public Task Add(CartDao addChartDao)
        {
            var cartItem = cartItemList.FirstOrDefault(c => c.CustomerId == addChartDao.CustomerId && c.ProductId == addChartDao.ProductId);
            if (cartItem != null)
                cartItemList.Remove(cartItem);

            cartItemList.Add(addChartDao);

            string json = JsonConvert.SerializeObject(cartItemList);

            File.WriteAllText(cartItemFilePath, json);

            return Task.CompletedTask;
        }
    }
}
