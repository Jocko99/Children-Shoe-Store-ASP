using Application;
using Application.Commands.Orders;
using Application.DataTransfer;
using Application.DataTransfer.OrdersDto;
using Application.Email;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Orders
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateOrderValidator _validator;
        private readonly IEmailSender _sender;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfCreateOrderCommand(ShoeStoreContext context, CreateOrderValidator validator, IMapper mapper, IApplicationActor actor, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
            _sender = sender;
        }

        public int Id => 305;

        public string Name => "Create Order using Ef.";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);
            var order = new Order
            {
                UserId = _actor.Id,
                Address = request.Address,
                OrderLines = request.OrderLines.Select(x =>
                {
                    var product = _context.ProductSizes
                    .Include(z => z.Size)
                    .Include(z => z.Product.Brand)
                    .Include(z => z.Product.Category)
                    .Include(z => z.Product)
                    .ThenInclude(z => z.Prices)
                    .FirstOrDefault(z => z.Id == x.ProductSizeId);
                    product.Quantity -= x.Quantity;
                    var getPrice = product.Product.Prices.Select(s => new PriceSearchDto
                    {
                        Date = s.CreatedAt,
                        Value = s.Value
                    }).OrderByDescending(x => x.Date).Take(1).ToList();
                    var price = getPrice.Select(s => s.Value).ToList();
                    return new OrderLines
                    {
                        Name = product.Product.Brand.Name + " " + product.Product.Category.Name,
                        Quantity = x.Quantity,
                        Size = product.Size.Value,
                        Price = price[0]
                    };
                }).ToList()
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            var user = _context.Users.Find(_actor.Id);
            var product = order.OrderLines.Select(x => x.Name).ToList();
            var quantity = order.OrderLines.Select(x => x.Quantity).ToList();
            var price = order.OrderLines.Select(x => x.Price).ToList();
            string message = "Proizvodi:\n";
            decimal totalPrice = 0;
            for(int i = 0; i< order.OrderLines.Count(); i++)
            {
                message += $"<p>{product[i]}, količina: {quantity[i]}</p>";
                totalPrice += quantity[i] * price[i];
            }
            message += $"Ukupno za placanje: <b>{totalPrice}</b>";
            _sender.Send(new SendEmailDto
            {
                Content = message.ToString(),
                SendTo = user.Email,
                Subject = "Porudzbina"
            });
        }
    }
}
