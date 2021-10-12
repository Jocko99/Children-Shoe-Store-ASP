using Application.Commands.Seasons;
using Application.DataTransfer;
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
    public class EfCreateSeasonCommand : ICreateSeasonCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateSeasonValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateSeasonCommand(ShoeStoreContext context, CreateSeasonValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Create new Season using Ef";

        public void Execute(SeasonDto request)
        {
            _validator.ValidateAndThrow(request);
            var season = _mapper.Map<Season>(request);
            _context.Add(season);
            _context.SaveChanges();
        }
    }
}
