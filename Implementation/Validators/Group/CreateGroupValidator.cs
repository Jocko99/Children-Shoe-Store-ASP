using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Group
{
    public class CreateGroupValidator : AbstractValidator<GroupDto>
    {
        public CreateGroupValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Group name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !_context.Groups.Any(y => y.Name == name)).WithMessage("Group with the name of {PropertyValue} already exists in database.");
            });
        }
    }
}
