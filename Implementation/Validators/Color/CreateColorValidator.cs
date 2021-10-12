using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Color
{
    public class CreateColorValidator : AbstractValidator<ColorDto>
    {
        public CreateColorValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Color value is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !_context.Colors.Any(y => y.Name == name)).WithMessage(c => $"Color with the name of {c.Name} already exists in database");
            });
        }
    }
}
