using Application;
using Application.Commands.Comments;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Comments
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteCommentCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 102;

        public string Name => throw new NotImplementedException();

        public void Execute(int request)
        {
            var productComment = _context.Comments.Find(request);
            if (productComment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }
            _context.Comments.Remove(productComment);
            _context.SaveChanges();
        }
    }
}
