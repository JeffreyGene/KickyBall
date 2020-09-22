using KickyBall.BLL.DTOs;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KickyBall.BLL.Services
{
    public class UserService : IUserService
    {
        private KickyBallContext _context;
        private PasswordHasher _passwordHasher;
        private IConfiguration Configuration;
        private IGameService _gameService;
        public UserService(KickyBallContext context, PasswordHasher passwordHasher, IConfiguration configuration, IGameService gameService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            Configuration = configuration;
            _gameService = gameService;
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
        public bool ResetPassword(ResetPasswordRequest request)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == request.UserId);
            user.Password = _passwordHasher.HashPassword(request.NewPassword);
            _context.SaveChanges();
            return true;
        }

        public List<AdminPageUser> GetUsers()
        {
            return _context.Users.Select(u => new AdminPageUser
            {
                UserId = u.UserId,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsAdmin = u.IsAdmin,
                GameFinished = u.Games.Any(g => g.Finished)
            }).ToList();
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public UserGameStats GetUserGameStats(int userId)
        {
            UserGameStats result = _context.Users
                .Include(u => u.Games)
                .ThenInclude(g => g.Rounds)
                .ThenInclude(r => r.GoalAttempts)
                .ThenInclude(ga => ga.Route)
                .Select(u => new UserGameStats
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    NormalAttempts = u.Games.FirstOrDefault().Rounds.Where(r => !r.Practice).SelectMany(r => r.GoalAttempts).Count(),
                    NormalGoals = u.Games.FirstOrDefault().Rounds.Where(r => !r.Practice).SelectMany(r => r.GoalAttempts.Where(ga => ga.ScoredGoal)).Count(),
                    PracticeGoals = u.Games.FirstOrDefault().Rounds.Where(r => r.Practice).SelectMany(r => r.GoalAttempts.Where(ga => ga.ScoredGoal)).Count(),
                    PracticeAttempts = u.Games.FirstOrDefault().Rounds.Where(r => r.Practice).SelectMany(r => r.GoalAttempts).Count(),
                    GameFinished = u.Games.Any(g => g.Finished),
                    RoundStats = u.Games.FirstOrDefault().Rounds.Select(r => new RoundStats
                    {
                        RoundId = r.RoundId,
                        Practice = r.Practice,
                        GoalAttemptRouteNames = r.GoalAttempts.Select(ga => ga.Route.Name)
                    })
                }).FirstOrDefault(u => u.UserId == userId);

            return result;
        }
    }
}
