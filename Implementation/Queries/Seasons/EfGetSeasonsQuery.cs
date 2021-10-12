using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Seasons
{
    public class EfGetSeasonsQuery : IGetSeasonQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetSeasonsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 407;

        public string Name => "Show seasons using Ef";

        public PageResponse<SeasonDto> Execute(SeasonSearch search)
        {
            var season = _context.Seasons.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                season = season.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return season.Paged<SeasonDto, Season>(search, _mapper);
        }
    }
}
