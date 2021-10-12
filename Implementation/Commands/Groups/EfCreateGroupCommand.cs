using Application.Commands.Groups;
using Application.DataTransfer;
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
    public class EfCreateGroupCommand : ICreateGroupCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateGroupValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateGroupCommand(ShoeStoreContext context, CreateGroupValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Create Group using Ef";

        public void Execute(GroupDto request)
        {
            _validator.ValidateAndThrow(request);
            var group = _mapper.Map<Group>(request);
            _context.Add(group);
            _context.SaveChanges();
        }
    }
}
