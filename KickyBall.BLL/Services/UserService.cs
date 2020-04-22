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
            string hashedPassword = _passwordHasher.HashPassword(request.Password);
            return _context.Users.FirstOrDefault(u => u.UserName == request.Username && u.Password == hashedPassword);
        }

        public User Register(RegistrationRequest request)
        {
            // Need to authenticate the registration code
            //string hashedRegistrationCode = _passwordHasher.HashPassword(request.RegistrationCode);
            //if(hashedRegistrationCode == null)
            //{

            //}
            User newUser = new User { UserName = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName };
            _context.Users.Add(newUser);
            return newUser;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
