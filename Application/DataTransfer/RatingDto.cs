using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class RatingDto : Dto
    {
        public int ProductId { get; set; }
        public float Value { get; set; }
    }
}
