using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Size : Entity
    {
        public int Value { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; } = new HashSet<ProductSize>();
    }
}
