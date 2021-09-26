using Domain.Models;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Interface for managing processes about stock events.
    /// </summary>
    public interface IStockEventService
    {
        Task Add(StockUpdateQueryRequest request);
    }
}
