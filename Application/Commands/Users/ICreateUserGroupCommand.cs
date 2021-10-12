using Application.DataTransfer.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public interface ICreateUserGroupCommand : ICommand<UserGroupDto>
    {
    }
}
