using Application.Commands.Categories;
using Application.DataTransfer;
using Application.Exceptions;
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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(ShoeStoreContext context, UpdateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Update category using Ef.";

        public void Execute(CategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }
            _validator.ValidateAndThrow(request);
            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }
}
