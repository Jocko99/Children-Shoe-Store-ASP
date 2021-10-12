using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.OrdersDto
{
    public class ReadOrderDto
    {
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string UserInfo { get; set; }
        public IEnumerable<ReadOrderLineDto> OrderLines { get; set; } = new List<ReadOrderLineDto>();
        public decimal TotalPrice => OrderLines.Sum(x => x.Price * x.Quantity);
    }
}
