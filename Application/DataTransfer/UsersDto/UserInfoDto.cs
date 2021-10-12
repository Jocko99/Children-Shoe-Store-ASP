using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.UsersDto
{
    public class UserInfoDto : UserDto
    {
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
