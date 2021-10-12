using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class PriceDto : Dto
    {
        public int ProductId { get; set; }
        public decimal Value { get; set; }       
    }
}
