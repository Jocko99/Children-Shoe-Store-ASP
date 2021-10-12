using Application.DataTransfer.OrdersDto;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Orders
{
    public class EfGetOrderQuery : IGetOrderQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetOrderQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 105;

        public string Name => "Ef show order using EF";

        public ReadOrderDto Execute(int search)
        {
            var orders = _context.Orders.Include(x => x.OrderLines).Include(x => x.User).FirstOrDefault(x => x.Id == search);

            if (orders == null)
            {
                throw new EntityNotFoundException(search,typeof(Order));
            }
            return _mapper.Map<ReadOrderDto>(orders);
        }
    }
}
