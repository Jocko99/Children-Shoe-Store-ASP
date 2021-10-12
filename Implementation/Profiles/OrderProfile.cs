using Application;
using Application.DataTransfer;
using Application.DataTransfer.OrdersDto;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile(/*IApplicationActor _actor, ShoeStoreContext _context*/)
        {

            CreateMap<Order, ReadOrderDto>()
            .ForMember(dto => dto.UserInfo, opt => opt.MapFrom(order => order.User.FirstName + " " + order.User.LastName + " " + order.User.Email))
            .ForMember(dto => dto.Status, opt => opt.MapFrom(order => order.OrderStatus.ToString()))
            .ForMember(dto => dto.OrderLines, opt => opt.MapFrom(order => order.OrderLines.Select(ol => new ReadOrderLineDto
            {
                Id = ol.Id,
                Name = ol.Name,
                Price = ol.Price,
                Quantity = ol.Quantity
            })));
        }
    }

    
}
