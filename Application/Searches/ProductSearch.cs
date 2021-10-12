using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class ProductSearch : PageSearch
    {
        public string Keyword { get; set; } // brand,description..
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public int? GenderId { get; set; }
        public int? SizeId { get; set; }
        public int? SeasonId { get; set; }
    }
}
