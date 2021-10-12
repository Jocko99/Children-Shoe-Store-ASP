using Application.Commands.Orders;
using Application.DataTransfer.OrdersDto;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Orders
{
    public class EfChangeOrderStatus : IChangeOrderStatus
    {
        private readonly ShoeStoreContext _context;

        public EfChangeOrderStatus(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 101;

        public string Name => "Change order status using Ef.";

        public void Execute(OrderStatusDto request)
        {
            var order = _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(x => x.ProductSize)
                .FirstOrDefault(x => x.Id == request.OrderId);

            if (order == null)
            {
                throw new EntityNotFoundException(request.OrderId, typeof(Order));
            }

            if (order.OrderStatus == OrderStatus.Delivered)
            {
                throw new ConflictException(typeof(Order));
            }

            if (order.OrderStatus == OrderStatus.Recieved || order.OrderStatus == OrderStatus.Shipped)
            {
                if (request.Status == OrderStatus.Canceled || request.Status == OrderStatus.Shipped)
                {
                    order.OrderStatus = request.Status;

                    if (request.Status == OrderStatus.Canceled)
                    {
                        foreach (var line in order.OrderLines)
                        {
                            line.ProductSize.Quantity += line.Quantity;
                        }
                    }
                    _context.SaveChanges();
                }
                throw new ConflictException(typeof(Order));
            }


        }

    }
}
