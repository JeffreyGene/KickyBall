using KickyBall.BLL.DTOs;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KickyBall.BLL.Services
{
    public class UserService : IUserService
    {
        private KickyBallContext _context;
        private PasswordHasher _passwordHasher;
        private IConfiguration Configuration;
        public UserService(KickyBallContext context, PasswordHasher passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            Configuration = configuration;
        }

        public AuthenticatedUser Authenticate(AuthenticationRequest request)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            var result = _passwordHasher.VerifyHashedPassword(user?.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Not Authorized");
            }

            // Setup JWT token for authentication
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Configuration["Settings:Secret"];
            var key = Encoding.ASCII.GetBytes(secret);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserId.ToString())
            };
            if (user.IsAdmin)
            {
                claims.Add(new Claim("kickyballAdmin", "true"));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return new AuthenticatedUser
            {
                UserId = user.UserId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                IsAdmin = user.IsAdmin
            };
        }

        public bool Register(RegistrationRequest request)
        {
            User currentUser = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if(currentUser != null)
            {
                throw new Exception("Not a valid username.");
            }
            string registrationCode = _context.ApplicationSettings.FirstOrDefault(s => s.ApplicationSettingCode == "URC").Value;
            string adminCode = _context.ApplicationSettings.FirstOrDefault(s => s.ApplicationSettingCode == "ARC").Value;
            bool isAdmin = false;
            if(request.RegistrationCode == adminCode)
            {
                isAdmin = true;
            }
            else if (request.RegistrationCode != registrationCode)
            {
                throw new Exception("Not a valid registration code.");
            }
            User newUser = new User { Username = request.Username, Password = _passwordHasher.HashPassword(request.Password), FirstName = request.FirstName, LastName = request.LastName, IsAdmin = isAdmin };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
