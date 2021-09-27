using Application;
using Domain;
using Domain.Models;
using FluentAssertions;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockTests
{
    public class StockUpdateQueryHandlerTests
    {
        private readonly Mock<IStockService> _stockService;

        private readonly Mock<IStockEventService> _stockEventService;

        private readonly IRequestHandler<StockUpdateQueryRequest, StockUpdateQueryResponse> _requestHandler;

        public StockUpdateQueryHandlerTests()
        {
            _stockService = new Mock<IStockService>();
            _stockEventService = new Mock<IStockEventService>();
            _requestHandler = new StockUpdateQueryHandler(_stockService.Object, _stockEventService.Object);
        }

        /// <summary>
        /// A unit test for checking zero stock case.
        /// </summary>
        [Fact]
        public async Task Handle_ZeroStock()
        {
            _stockService.Setup(s => s.UpdateStock(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(0);

            var request = new StockUpdateQueryRequest { Amount = 3, CustomerId = 1, ProductId = 2 };

            var stockUpdateQueryResponse = await _requestHandler.Handle(request, It.IsAny<CancellationToken>());
            stockUpdateQueryResponse.AvailableStockCount.Should().Be(0);
            stockUpdateQueryResponse.Message.Should().Be(StockConstants.NoStockMessage);
        }

        /// <summary>
        /// A unit test for checking the case where stock is not zero but not enough either.
        /// </summary>
        [Fact]
        public async Task Handle_NotEnoughStock()
        {
            int requestedStock = 3, availableStock = 1;

            _stockService.Setup(s => s.UpdateStock(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(availableStock);

            var request = new StockUpdateQueryRequest { Amount = requestedStock, CustomerId = 1, ProductId = 2 };

            var stockUpdateQueryResponse = await _requestHandler.Handle(request, It.IsAny<CancellationToken>());
            stockUpdateQueryResponse.AvailableStockCount.Should().Be(availableStock);
            stockUpdateQueryResponse.Message.Should().Be(string.Format(StockConstants.NotEnoughStockMessage, requestedStock, availableStock));
        }

        /// <summary>
        /// A unit test for checking the case where requested stock is available.
        /// </summary>
        [Fact]
        public async Task Handle_AvailableStock()
        {
            int requestedStock = 3, availableStock = 4;

            _stockService.Setup(s => s.UpdateStock(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(availableStock);

            var request = new StockUpdateQueryRequest { Amount = requestedStock, CustomerId = 1, ProductId = 2 };

            var stockUpdateQueryResponse = await _requestHandler.Handle(request, It.IsAny<CancellationToken>());
            stockUpdateQueryResponse.AvailableStockCount.Should().Be(availableStock);
            stockUpdateQueryResponse.Message.Should().BeNull();
        }
    }
}
