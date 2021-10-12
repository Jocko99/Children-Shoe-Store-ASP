using Application.DataTransfer.UsersDto;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Jwt
{
    public class JwtManager
    {
        private readonly ShoeStoreContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;

        public JwtManager(ShoeStoreContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string email,string password)
        {
            var user = _context.Users.Include(ug => ug.UserGroups).ThenInclude(g => g.Group).FirstOrDefault(x => x.Email == email && x.Password == password);
            
            if(user == null)
            {
                return null;
            }
            //var usecases = _context.UserUseCases.Where(x => user.UserGroups.Any(y => y.GroupId == x.GroupId)).Select(x => x.UseCaseId).ToList();
            var groups = user.UserGroups.Select(x => x.GroupId);
            List<int> usecases = new List<int>();
            foreach(var item in groups)
            {
                usecases.AddRange(_context.UserUseCases.Where(x => x.GroupId == item).Select(x => x.UseCaseId));
            }
            //var usecases = _context.UserUseCases.Where(x).Select(x => x.UseCaseId).ToList();

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = usecases,
                Identity = user.Email
            };

            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, _issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
