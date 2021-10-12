using Application.DataTransfer.OrdersDto;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Order
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        public CreateOrderValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.OrderLines).NotEmpty().WithMessage("There must be at least one order line")
                .Must(x => x.Select(y => y.ProductSizeId).Distinct().Count() == x.Count())
                .DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new CreateOrderLineValidator(_context));
                });
        }
    }
}
