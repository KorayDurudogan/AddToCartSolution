using Domain.Models;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Interface for managing processes about StockAPI.
    /// </summary>
    public interface IStockService
    {
        Task<AddCartResponseDto> Call(AddCartRequest addCartDto, string token);
    }
}
