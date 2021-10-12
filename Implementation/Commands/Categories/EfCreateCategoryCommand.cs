using Application.Commands.Categories;
using Application.DataTransfer;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Categories
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;
        public EfCreateCategoryCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public EfCreateCategoryCommand(ShoeStoreContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Create new category using Ef";

        public void Execute(CategoryDto request)
        {

            _validator.ValidateAndThrow(request);
            var category = _mapper.Map<Category>(request);
            _context.Add(category);
            _context.SaveChanges();
        }
    }
}
