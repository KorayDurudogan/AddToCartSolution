using Application;
using AutoMapper;
using Domain;
using Domain.Models;
using FluentAssertions;
using Infrastructure.DataSourceContext;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CartTests
{
    public class CartServiceTests
    {
        private readonly Mock<ICartDataContext> _cartDataContext;

        private readonly Mock<ITokenProvider> _tokenProvider;

        private readonly Mock<IMapper> _mapper;

        private readonly Mock<IStockService> _stockService;

        private readonly ICartService _cartService;

        public CartServiceTests()
        {
            _cartDataContext = new Mock<ICartDataContext>();
            _tokenProvider = new Mock<ITokenProvider>();
            _mapper = new Mock<IMapper>();
            _stockService = new Mock<IStockService>();
            _cartService = new CartService(_tokenProvider.Object, _cartDataContext.Object, _mapper.Object, _stockService.Object);
        }

        /// <summary>
        /// A unit test for checking the case where request is null
        /// </summary>
        [Fact]
        public async Task AddToCart_ArgumentNullException_NullRequest()
        {
            var exception = await Record.ExceptionAsync(() => _cartService.AddToCart(It.IsAny<AddCartRequest>()));
            exception.Should().BeOfType(typeof(ArgumentNullException));
        }

        /// <summary>
        /// A unit test for checking the case where one of the values is zero.
        /// </summary>
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 2)]
        [InlineData(1, 2, 0)]
        public async Task AddToCart_ArgumentNullException_ZeroValues(int amount, int productId, int customerId)
        {
            var request = new AddCartRequest { Amount = amount, ProductId = productId, CustomerId = customerId };

            var exception = await Record.ExceptionAsync(() => _cartService.AddToCart(request));
            exception.Should().BeOfType(typeof(ArgumentNullException));
        }
    }
}
