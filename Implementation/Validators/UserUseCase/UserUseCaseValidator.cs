using Application.DataTransfer.UsersDto;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UserUseCase
{
    public class UserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        public UserUseCaseValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group is required").DependentRules(() =>
            {
                RuleFor(x => x.GroupId).Must(group => _context.Groups.Any(y => y.Id == group)).WithMessage(c => $"Group with an id of {c.Id} doesn't exists in database");
            });
            RuleFor(x => x.UseCaseId).NotEmpty().WithMessage("Use case is required").DependentRules(() =>
            {
                RuleFor(x => x.UseCaseId).Must((dto, usecase) => !_context.UserUseCases.Any(y => y.UseCaseId == usecase && y.GroupId == dto.GroupId)).WithMessage("There can't be duplicated use cases for one group");
            });
        }
    }
}
