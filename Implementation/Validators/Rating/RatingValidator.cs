using Application;
using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Rating
{
    public class RatingValidator : AbstractValidator<RatingDto>
    {
        public RatingValidator(ShoeStoreContext _context)
        {
           
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id is required").DependentRules(() =>
            {
                RuleFor(x => x.ProductId).Must(x => _context.Products.Any(y => y.Id == x)).WithMessage("Entity with an of product {PropertyValue} doesn't exists");
            });
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Rating must be above 0.").LessThan(6).WithMessage("Rating can't be more then 5");
        }
    }
}
