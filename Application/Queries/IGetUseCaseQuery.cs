using Application.DataTransfer.UsersDto;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IGetUseCaseQuery : IQuery<UseCaseSearch, PageResponse<UserUseCaseSearchDto>>
    {
    }
}
