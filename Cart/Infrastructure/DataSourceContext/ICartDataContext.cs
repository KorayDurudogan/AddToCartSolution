using Infrastructure.Models;
using System.Threading.Tasks;

namespace Infrastructure.DataSourceContext
{
    /// <summary>
    /// Interface for manipulating to data source json.
    /// </summary>
    public interface ICartDataContext
    {
        Task Add(CartDao addChartDao);
    }
}
