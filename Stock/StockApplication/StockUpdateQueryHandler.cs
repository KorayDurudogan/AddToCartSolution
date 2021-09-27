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

            if (updatedStockCount == 0) //In case we have zero products in stock.
            {
                response.Message = StockConstants.NoStockMessage;
                return response;
            }
            else if (updatedStockCount < request.Amount) //In case we have products in stock but not as much as requested.
            {
                response.Message = string.Format(StockConstants.NotEnoughStockMessage, request.Amount, updatedStockCount);
                request.Amount = updatedStockCount;
            }

            await _stockEventService.Add(request);

            return response;
        }
    }
}
