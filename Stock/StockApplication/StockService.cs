using Domain;
using Infrastructure.DataSourceContext;
using System.Threading.Tasks;

namespace Application
{
    public class StockService : IStockService
    {
        private readonly IStockDataContext _stockDataContext;

        public StockService(IStockDataContext stockDataContext) => _stockDataContext = stockDataContext;

        public async Task<int> UpdateStock(int productId, int amountId)
        {
            int stockCount = await _stockDataContext.GetStock(productId);

            if (stockCount == 0)
                return 0;

            int availableStockCount = stockCount < amountId ? stockCount : amountId;

            await _stockDataContext.DecreaseStock(productId, availableStockCount);

            return availableStockCount;
        }
    }
}
