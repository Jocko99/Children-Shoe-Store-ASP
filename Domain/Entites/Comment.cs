using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Comment : Entity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
