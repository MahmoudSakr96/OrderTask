using AutoMapper;
using OlderTask.Domain.Entities;
using OrderTask.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTask.Business
{
    public class ApplicationAutoMapperProfile:Profile
    {
        public ApplicationAutoMapperProfile()
        {
            this.CreateMap<OrderDto, Order>().ReverseMap();
            this.CreateMap<OrderDetailsDto, OrderDetail>().ReverseMap();
            this.CreateMap<ApplicationUser, UserDto>().ReverseMap();
        }
    }
}
