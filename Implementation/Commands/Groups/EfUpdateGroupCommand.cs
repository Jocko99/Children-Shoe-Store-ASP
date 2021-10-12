using Application.Commands.Groups;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Groups
{
    public class EfUpdateGroupCommand : IUpdateGroupCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateGroupValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateGroupCommand(ShoeStoreContext context, UpdateGroupValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Update Group using Ef";

        public void Execute(GroupDto request)
        {
            var group = _context.Groups.Find(request.Id);
            if (group == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Group));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, group);
            _context.SaveChanges();
        }
    }
}
