using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class CommentDto : Dto
    {
        public string User { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
    }
}
