using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickyBall.BLL.Services
{
    public class UserService : IUserService
    {
        private KickyBallContext _context;
        private PasswordHasher _passwordHasher;
        public UserService(KickyBallContext context, PasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public User Authenticate(AuthenticationRequest request)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            var result = _passwordHasher.VerifyHashedPassword(user?.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Not Authorized");
            }
            return user;
        }

        public User Register(RegistrationRequest request)
        {
            // Need to authenticate the registration code
            //string hashedRegistrationCode = _passwordHasher.HashPassword(request.RegistrationCode);
            //if(hashedRegistrationCode == null)
            //{

            //}
            bool isAdmin = false;
            if(request.RegistrationCode == "WaterBender")
            {
                isAdmin = true;
            }
            User newUser = new User { Username = request.Username, Password = _passwordHasher.HashPassword(request.Password), FirstName = request.FirstName, LastName = request.LastName, IsAdmin = isAdmin };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
