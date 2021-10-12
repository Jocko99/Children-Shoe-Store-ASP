using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class UserUseCase : Entity
    {
        public int GroupId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Group Group { get; set; }
    }
}
