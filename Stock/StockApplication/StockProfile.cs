using AutoMapper;
using Domain.Models;
using Infrastructure.DaoModels;
using System;

namespace Application
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            var random = new Random();

            CreateMap<StockUpdateQueryRequest, StockEventDao>()
                   .ForMember(x => x.Id, y => y.MapFrom(dto => random.Next(1, 100000)))
                   .ForMember(x => x.StockChange, y => y.MapFrom(dto => dto.Amount))
                   .ForMember(x => x.Date, y => y.MapFrom(dto => DateTime.Now));

            CreateMap<AddCartRequest, StockUpdateQueryRequest>();

            CreateMap<StockUpdateQueryResponse, AddCartResponse>();
        }
    }
}
