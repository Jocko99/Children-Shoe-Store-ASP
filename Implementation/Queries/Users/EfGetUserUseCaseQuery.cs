using Application.DataTransfer.UsersDto;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Users
{
    public class EfGetUserUseCaseQuery : IGetUseCaseQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetUserUseCaseQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 305;

        public string Name => "Show Use Cases using Ef";

        public PageResponse<UserUseCaseSearchDto> Execute(UseCaseSearch search)
        {
            var useCase = _context.UserUseCases.Include(x => x.Group).AsQueryable();
            if (search.UseCaseId.HasValue)
            {
                useCase = useCase.Where(x => x.UseCaseId == search.UseCaseId);
            }
            return useCase.Paged<UserUseCaseSearchDto, UserUseCase>(search, _mapper);
        }
    }
}
