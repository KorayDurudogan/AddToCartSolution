using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Interface for managing processes about stocks.
    /// </summary>
    public interface IStockService
    {
        Task<int> UpdateStock(int productId, int amountId);
    }
}
