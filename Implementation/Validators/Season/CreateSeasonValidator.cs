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
    public class CreateSeasonValidator : AbstractValidator<SeasonDto>
    {
        public CreateSeasonValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Season name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !_context.Seasons.Any(y => y.Name == name)).WithMessage(c => $"Season with the name of {c.Name} already exists in database");
            });
        }
    }
}
