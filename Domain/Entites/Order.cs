using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; } = new HashSet<OrderLines>();
       
    }
    public enum OrderStatus
    {
        Recieved,
        Delivered,
        Shipped,
        Canceled
    }
}
