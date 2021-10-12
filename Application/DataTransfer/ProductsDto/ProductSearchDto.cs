using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.ProductsDto
{
    public class ProductSearchDto : Dto
    {
        public string Name { get; set; } // BrandName + CategoryName, + Gender
        public string Image { get; set; }
        public IEnumerable<PriceSearchDto> Price { get; set; } = new List<PriceSearchDto>();
    }
}
