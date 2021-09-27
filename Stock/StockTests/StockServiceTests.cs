using Application;
using Domain;
using FluentAssertions;
using Infrastructure.DataSourceContext;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace StockTests
{
    public class StockServiceTests
    {
        private readonly IStockService _stockService;

        private readonly Mock<IStockDataContext> _stockDataContext;

        public StockServiceTests()
        {
            _stockDataContext = new Mock<IStockDataContext>();
            _stockService = new StockService(_stockDataContext.Object);
        }

        /// <summary>
        /// A unit test for checking zero stock case.
        /// </summary>
        [Fact]
        public async Task Add_ZeroStock()
        {
            _stockDataContext.Setup(s => s.GetStock(It.IsAny<int>())).ReturnsAsync(0);
            
            int stock = await _stockService.UpdateStock(1, 3);
            stock.Should().Be(0);
        }

        /// <summary>
        /// A unit test for checking the case where we have product in stock but not as much as requested.
        /// </summary>
        [Fact]
        public async Task Add_LesserThanRequested()
        {
            _stockDataContext.Setup(s => s.GetStock(It.IsAny<int>())).ReturnsAsync(1);

            int stock = await _stockService.UpdateStock(1, 3);
            stock.Should().Be(1);
        }

        /// <summary>
        /// A unit test for case where stock is available.
        /// </summary>
        [Fact]
        public async Task Add_StockAvailable()
        {
            _stockDataContext.Setup(s => s.GetStock(It.IsAny<int>())).ReturnsAsync(5);

            int stock = await _stockService.UpdateStock(1, 3);
            stock.Should().Be(3);
        }
    }
}
