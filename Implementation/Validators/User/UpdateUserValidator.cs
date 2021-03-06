using Application.DataTransfer.UsersDto;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.UserGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UserInfoDto>
    {
        public UpdateUserValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").DependentRules(() =>
            {
                RuleFor(x => x.Email).Must((dto, email) => !_context.Users.Any(y => y.Email == email && y.Id != dto.Id)).WithMessage(e => $"The email address {e.Email} is already taken.");
            });
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required").DependentRules(() =>
            {
                RuleFor(x => x.PhoneNumber).Must((dto, phone) => !_context.Users.Any(y => y.PhoneNumber == phone && y.Id != dto.Id)).WithMessage(p => $"The phone number {p.PhoneNumber} is already taken.");
            });
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required").MaximumLength(50).WithMessage("Maximum length of First name is 50 character.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First name is required").MaximumLength(50).WithMessage("Maximum length of Last name is 50 character."); ;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Minimum length of password is 6 character.");
        }
    }
}

