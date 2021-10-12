using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class OrderLines : Entity
    {
        public int OrderId { get; set; }
        public int? ProductSizeId { get; set; }
        public string Name { get; set; } // Brand name
        public int Quantity { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductSize ProductSize { get; set; }
    }
}
