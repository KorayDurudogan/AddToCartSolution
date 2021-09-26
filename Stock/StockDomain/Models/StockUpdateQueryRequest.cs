using MediatR;

namespace Domain.Models
{
    public class StockUpdateQueryRequest : IRequest<StockUpdateQueryResponse>
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public int CustomerId { get; set; }
    }
}
