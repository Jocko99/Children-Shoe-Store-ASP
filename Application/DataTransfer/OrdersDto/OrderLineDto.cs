using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.OrdersDto
{
    public class OrderLineDto : Dto 
    {
        public int ProductSizeId { get; set; }
        public int Quantity { get; set; }
    }
}
