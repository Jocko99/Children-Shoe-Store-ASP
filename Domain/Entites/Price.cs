using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Price : Entity
    {
        public int ProductId { get; set; }
        public decimal Value { get; set; }
        public virtual Product Product { get; set; }
    }
}
