using AutoMapper;
using Domain;
using Domain.Models;
using Infrastructure.DaoModels;
using Infrastructure.DataSourceContext;
using System.Threading.Tasks;

namespace Application
{
    public class StockEventService : IStockEventService
    {
        private readonly IMapper _mapper;

        private readonly IStockEventDataContext _stockEventDataContext;

        public StockEventService(IMapper mapper, IStockEventDataContext stockEventDataContext)
        {
            _mapper = mapper;
            _stockEventDataContext = stockEventDataContext;
        }

        public async Task Add(StockUpdateQueryRequest request)
        {
            var stockEventDao = _mapper.Map<StockEventDao>(request);
            await _stockEventDataContext.Add(stockEventDao);
        }
    }
}
