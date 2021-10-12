using Application;
using Application.Commands.Ratings;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Ratings
{
    public class EfCreateRatingCommand : ICreateRatingCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly RatingValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;
        public EfCreateRatingCommand(ShoeStoreContext context, RatingValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 301;

        public string Name => "Create Rating using Ef";

        public void Execute(RatingDto request)
        {
            _validator.ValidateAndThrow(request);
            if (_context.Ratings.Any(x => x.UserId == _actor.Id))
            {
                throw new ConflictException(typeof(Rating));
            }
            var rating = new Rating
            {
                ProductId = request.ProductId,
                Value = request.Value,
                UserId = _actor.Id
            };
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }
    }
}
