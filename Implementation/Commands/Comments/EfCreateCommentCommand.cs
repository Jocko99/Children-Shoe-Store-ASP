using Application;
using Application.Commands.Comments;
using Application.DataTransfer;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Comments
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CommentValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateCommentCommand(ShoeStoreContext context, CommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 303;

        public string Name => "Create new Comment using Ef";

        public void Execute(CommentDto request)
        {
            _validator.ValidateAndThrow(request);
            var comment = new Comment
            {
                UserId = _actor.Id,
                ProductId = request.ProductId,
                Text = request.Text
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
