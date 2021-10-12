using Application.DataTransfer.UsersDto;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserGroup
{
    public class UserGroupValidator : AbstractValidator<UserGroupDto>
    {
        public UserGroupValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id is required").DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(user => _context.Users.Any(x => x.Id == user)).WithMessage("User with an id of {PropertyValue} doesn't exists in database.");
            });
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group id is required").DependentRules(() =>
            {
                RuleFor(x => x.GroupId).Must(gId => _context.Groups.Any(x => x.Id == gId)).WithMessage("Group with an id of {PropertyValue} doesn't exists in database.").DependentRules(() =>
                {
                    RuleFor(x => x.GroupId).Must((dto, ug) => !_context.UserGroups.Any(x => x.GroupId == ug && x.UserId == dto.UserId)).WithMessage("User is already in this group.");
                });
            });
            
        }
    }
}
