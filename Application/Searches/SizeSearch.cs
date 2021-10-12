using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class SizeSearch : PageSearch
    {
        public int? Value { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
    }
}
