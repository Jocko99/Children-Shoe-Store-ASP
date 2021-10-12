using Application.Commands.Users;
using Application.DataTransfer;
using Application.DataTransfer.UsersDto;
using Application.Email;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UserRegistrationValidator _validator;
        private readonly IMapper _mapper;
        private readonly IEmailSender _sender;
        public EfRegisterUserCommand(ShoeStoreContext context, UserRegistrationValidator validator, IMapper mapper, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _sender = sender;
        }

        public int Id => 500;

        public string Name => "Register User using Ef";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _mapper.Map<User>(request);
            _context.Add(user);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Dobrodošli</h1>" +
                "<p>Uspešno ste se registrovali na prodavnicu obuće.</p>" +
                "<p>Ukoliko ovo niste vi, kontaktirajte nas putem email adrese.",
                SendTo = request.Email,
                Subject = "Registracija"
            });
        }
    }
}
