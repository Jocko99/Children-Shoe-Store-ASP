using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Size
{
    public class UpdateSizeValidator : AbstractValidator<SizeDto>
    {
        public UpdateSizeValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Size value must be greater than 0.").DependentRules(() =>
                {
                    RuleFor(x => x.Value).Must((dto, value) => !_context.Sizes.Any(y => y.Value == value && y.Id != dto.Id)).WithMessage(p => $"Size with the value {p.Value} already exists in database");
            });
        }
    }
}
