using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Genders
{
    public interface IUpdateGenderCommand : ICommand<GenderDto>
    {
    }
}
