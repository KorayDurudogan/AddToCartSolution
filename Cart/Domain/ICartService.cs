using Domain.Models;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Interface for managing processes about carts.
    /// </summary>
    public interface ICartService
    {
        Task<AddCartResponseDto> AddToCart(AddCartRequest addChartDto);
    }
}
