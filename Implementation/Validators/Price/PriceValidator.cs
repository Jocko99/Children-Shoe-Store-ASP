using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Price
{
    public class PriceValidator : AbstractValidator<PriceDto>
    {
        public PriceValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Price must be above 0");
        }
    }
}
