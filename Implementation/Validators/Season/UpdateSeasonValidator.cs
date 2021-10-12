using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Season
{
    public class UpdateSeasonValidator : AbstractValidator<SeasonDto>
    {
        public UpdateSeasonValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Season name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !_context.Seasons.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(c => $"Season with the name of {c.Name} already exists in database");
            });
        }
    }
}
