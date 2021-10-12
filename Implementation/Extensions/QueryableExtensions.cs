using Application.Queries;
using Application.Searches;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PageResponse<TDto> Paged<TDto, TEntity>(this IQueryable<TEntity> query, PageSearch search, IMapper mapper) where TDto : class
        {
            var skipCount = search.PerPage * (search.Page - 1);
            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var response = new PageResponse<TDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };

            return response;
        }
    }
}
