using Application.DataTransfer.OrdersDto;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Orders
{
    public class EfGetOrdersQuery : IGetOrdersQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;
        public EfGetOrdersQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 106;

        public string Name => "Show Orders using Ef";

        public PageResponse<ReadOrderDto> Execute(OrderSearch search)
        {
            var orders = _context.Orders
                        .Include(x => x.User)
                        .Include(x => x.OrderLines).AsQueryable();

            //gradjenje upita

            if (search.MinOrderLines.HasValue)
            {
                orders = orders.Where(order => order.OrderLines.Count() >= search.MinOrderLines.Value);
            }

            if (search.Status.HasValue)
            {
                orders = orders.Where(o => o.OrderStatus == search.Status);
            }

            if (search.MinPrice.HasValue)
            {
                orders = orders.Where(o => o.OrderLines.Sum(x => x.Quantity * x.Price) >= search.MinPrice.Value);
            }

            return orders.Paged<ReadOrderDto, Order>(search, _mapper);
        }
    }
}
