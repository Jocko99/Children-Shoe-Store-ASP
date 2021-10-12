using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.ProductsDto
{
    public class ProductDto : Dto
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int GenderId { get; set; }
        public int SeasonId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; } = true;
        public IEnumerable<ProductSizeDto> ProductSizes { get; set; } = new List<ProductSizeDto>();
        public IEnumerable<PriceDto> Prices { get; set; } = new List<PriceDto>();
    }
}
