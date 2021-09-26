using Domain;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class StockUpdateQueryHandler : IRequestHandler<StockUpdateQueryRequest, StockUpdateQueryResponse>
    {
        private readonly IStockService _stockService;

        private readonly IStockEventService _stockEventService;

        public StockUpdateQueryHandler(IStockService stockService, IStockEventService stockEventService)
        {
            _stockService = stockService;
            _stockEventService = stockEventService;
        }

        public async Task<StockUpdateQueryResponse> Handle(StockUpdateQueryRequest request, CancellationToken cancellationToken)
        {
            int updatedStockCount = await _stockService.UpdateStock(request.ProductId, request.Amount);

            var response = new StockUpdateQueryResponse { AvailableStockCount = updatedStockCount };

            if (updatedStockCount < request.Amount)
            {
                response.Message = $"Customer requested {request.Amount} number of products but we have only {updatedStockCount} number of products in our stock.";
                request.Amount = updatedStockCount;
            }

            await _stockEventService.Add(request);

            return response;
        }
    }
}
