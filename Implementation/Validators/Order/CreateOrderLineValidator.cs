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
    public class CreateOrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public CreateOrderLineValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.ProductSizeId).Must(x => _context.ProductSizes.Any(y => y.Id == x)).WithMessage("Product doesn't exists")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Quantity).Must(x => x > 0).WithMessage("Quantity must be greather then 0.").DependentRules(() =>
                    {
                        RuleFor(x => x.Quantity).Must(x => _context.ProductSizes.Any(y => y.Quantity > x)).WithMessage("We don't have enought quantity on stock.");
                    });
                });
            
        }
    }
}
