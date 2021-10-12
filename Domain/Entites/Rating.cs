using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Rating : Entity
    {
        public int? UserId { get; set; }
        public int ProductId { get; set; }
        public float Value { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
