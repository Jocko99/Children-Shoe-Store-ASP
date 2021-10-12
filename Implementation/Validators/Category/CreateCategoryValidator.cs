using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is requred.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !_context.Categories.Any(y => y.Name == name)).WithMessage(name => $"Category with the name of {name.Name} already exists in database");
            });
        }
    }
}
