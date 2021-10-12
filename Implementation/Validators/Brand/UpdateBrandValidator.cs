using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Brand
{
    public class UpdateBrandValidator : AbstractValidator<BrandDto>
    {
        public UpdateBrandValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto,name) => !_context.Brands.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(b => $"Brand with the name of {b.Name} already exists in database");
            });
            RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo is required").DependentRules(() =>
            {
                RuleFor(x => x.Logo).Must((dto,logo) => !_context.Brands.Any(y => y.Logo == logo && y.Id != dto.Id)).WithMessage(l => $"Logo with the name of {l.Logo} already exists in database");
            });
        }
    }
}
