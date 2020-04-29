using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KickyBall.BLL.DTOs;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.BLL.Services;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KickyBall.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public AuthenticatedUser Authenticate([FromBody]AuthenticationRequest request)
        {
            return _service.Authenticate(request);
        }

        [HttpPost]
        public User Register([FromBody]RegistrationRequest request)
        {
            return _service.Register(request);
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _service.GetUsers();
        }
    }
}
