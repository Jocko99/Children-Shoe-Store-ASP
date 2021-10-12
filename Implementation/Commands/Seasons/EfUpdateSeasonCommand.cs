using Application.Commands.Seasons;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Seasons
{
    public class EfUpdateSeasonCommand : IUpdateSeasonCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateSeasonValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateSeasonCommand(ShoeStoreContext context, UpdateSeasonValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 21;

        public string Name => "Update Season using Ef";

        public void Execute(SeasonDto request)
        {
            var season = _context.Seasons.Find(request.Id);
            if (season == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Season));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, season);
            _context.SaveChanges();
        }
    }
}
