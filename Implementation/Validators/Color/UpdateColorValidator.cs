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
    public class UpdateColorValidator : AbstractValidator<ColorDto>
    {
        public UpdateColorValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Color value is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !_context.Colors.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(c => $"Color with the name of {c.Name} already exists in database");
            });
        }
    }
}
