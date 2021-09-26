using AutoMapper;
using Domain;
using Domain.Models;
using Infrastructure.DataSourceContext;
using Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class CartService : ICartService
    {
        private readonly ICartDataContext _cartDataContext;

        private readonly ITokenProvider _tokenProvider;

        private readonly IMapper _mapper;

        private readonly IStockService _stockService;

        public CartService(ITokenProvider tokenProvider, ICartDataContext cartDataContext, IMapper mapper, IStockService stockService)
        {
            _tokenProvider = tokenProvider;
            _cartDataContext = cartDataContext;
            _mapper = mapper;
            _stockService = stockService;
        }

        public async Task<AddCartResponseDto> AddToCart(AddCartRequest addCartDto)
        {
            if (addCartDto.Amount == 0 || addCartDto.CustomerId == 0 || addCartDto.ProductId == 0)
                throw new ArgumentNullException();

            string token = await _tokenProvider.GetToken();

            var stockResponse = await _stockService.Call(addCartDto, token);

            var cartDao = _mapper.Map<CartDao>(addCartDto);
            cartDao.Amount = stockResponse.AvailableStockCount;

            await _cartDataContext.Add(cartDao);

            return stockResponse;
        }
    }
}
