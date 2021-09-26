using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public StockController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<AddCartResponse> Put(AddCartRequest request)
        {
            var stockUpdateQueryRequest = _mapper.Map<StockUpdateQueryRequest>(request);
            var response = await _mediator.Send(stockUpdateQueryRequest);
            return _mapper.Map<AddCartResponse>(response);
        }
    }
}
