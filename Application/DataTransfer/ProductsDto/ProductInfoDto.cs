using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.ProductsDto
{
    public class ProductInfoDto : Dto
    {
        public string Name { get; set; } //BrandName
        public string Color { get; set; }
        public string Season { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IEnumerable<RatingDto> Ratings { get; set; } = new List<RatingDto>();
        public IEnumerable<PriceSearchDto> Price { get; set; } = new List<PriceSearchDto>();
        public IEnumerable<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public IEnumerable<SizeDto> Size { get; set; } = new List<SizeDto>();
    }
}
