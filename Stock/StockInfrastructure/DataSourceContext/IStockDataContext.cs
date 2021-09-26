using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    /// <summary>
    /// Interface for manipulating to data source Stock.json.
    /// </summary>
    public interface IStockDataContext
    {
        Task DecreaseStock(int productId, int amount);

        Task<int> GetStock(int productId);
    }
}
