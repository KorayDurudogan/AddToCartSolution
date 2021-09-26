using Infrastructure.DaoModels;
using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    /// <summary>
    /// Interface for manipulating to data source StockEvent.json.
    /// </summary>
    public interface IStockEventDataContext
    {
        Task Add(StockEventDao stockEventDao);
    }
}
