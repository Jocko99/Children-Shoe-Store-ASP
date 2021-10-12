using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Gender
{
    public class UpdateGenderValidator : AbstractValidator<GenderDto>
    {
        public UpdateGenderValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Gender name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto,name) => !_context.Genders.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(c => $"Gender with the name of {c.Name} already exists in database");
            });
        }
    }
}
