using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.UsersDto
{
    public class UserUseCaseDto : Dto
    {
        public int GroupId { get; set; }
        public int UseCaseId { get; set; }
    }
}
