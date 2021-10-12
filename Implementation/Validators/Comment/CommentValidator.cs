using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Comment
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id is required").DependentRules(() =>
            {
                RuleFor(x => x.ProductId).Must(x => _context.Products.Any(y => y.Id == x)).WithMessage("Product with an id of {PropertyValue} doesn't exists");
            });
            RuleFor(x => x.Text).MinimumLength(3).WithMessage("Text need to have minimum 3 character.");
        }
    }
}
