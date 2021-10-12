using Application.DataTransfer.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IGetUserQuery : IQuery<int, UserSearchDto>
    {
    }
}
