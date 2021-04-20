using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo_API.Interfaces;
using Demo_API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Demo_API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;

        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private readonly List<User> users = new List<User>()
        {
            new User { UserId = 1, Username = "himanshulimbasiya", Name = "Himanshu Limbasiya", Password = "himanshu"},
            new User { UserId = 2, Username = "lionelmessi", Name = "Lionel Messi", Password = "messi"},
            new User { UserId = 3, Username = "christianoronaldo", Name = "Christiano Ronaldo", Password = "ronaldo"},
            new User { UserId = 1, Username = "neymarJr", Name = "Neymar JR", Password = "neymar"}
        };

        public User Login(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.Username == userName && x.Password == password);

            if (user == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Version, "V3.1")
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;
            }
        }
    }
}
