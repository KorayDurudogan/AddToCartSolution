using AutoMapper;
using Domain.Models;
using Infrastructure.Models;
using System;

namespace Application
{
    public class CartProfile : Profile
    {
        /// <summary>
        /// Automapper profile for model conversions.
        /// </summary>
        public CartProfile()
        {
            var random = new Random();

            CreateMap<AddCartRequest, CartDao>()
                   .ForMember(x => x.AddToCartDate, y => y.MapFrom(dto => DateTime.Now))
                   .ForMember(x => x.Id, y => y.MapFrom(dto => random.Next(1, 100000)));
        }
    }
}
