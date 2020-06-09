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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KickyBall.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApplicationSettingController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IApplicationSettingService _service;

        public ApplicationSettingController(ILogger<UserController> logger, IApplicationSettingService service)
        {
            _logger = logger;
            _service = service;
        }

        [Authorize(Policy = "KickyBallAdmin")]
        [HttpGet]
        public List<ApplicationSetting> GetApplicationSettings()
        {
            return _service.GetApplicationSettings();
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpGet]
        public List<ApplicationSetting> GetGameSettings()
        {
            return _service.GetGameSettings();
        }

        [Authorize(Policy = "KickyBallAdmin")]
        [HttpPost]
        public ApplicationSetting UpdateSetting(ApplicationSetting setting)
        {
            return _service.UpdateSetting(setting);
        }

        [HttpGet]
        public string GetWelcomeSetting()
        {
            return _service.GetWelcomeSetting();
        }
    }
}
