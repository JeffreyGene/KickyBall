﻿using System;
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
using OfficeOpenXml;

namespace KickyBall.Application.Controllers
{
    [Authorize(Policy = "KickyBallAdmin")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        private readonly IRouteService _routeService;

        public UserController(ILogger<UserController> logger, IUserService service, IRouteService routeService)
        {
            _logger = logger;
            _service = service;
            _routeService = routeService;
        }

        [AllowAnonymous]
        [HttpPost]
        public AuthenticatedUser Authenticate([FromBody]AuthenticationRequest request)
        {
            return _service.Authenticate(request);
        }

        [AllowAnonymous]
        [HttpPost]
        public bool Register([FromBody]RegistrationRequest request)
        {
            return _service.Register(request);
        }

        [HttpPost]
        public bool ResetPassword([FromBody]ResetPasswordRequest request)
        {
            return _service.ResetPassword(request);
        }

        [HttpGet]
        public List<AdminPageUser> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet]
        public UserGameStats GetUserGameStats(int userId)
        {
            return _service.GetUserGameStats(userId);
        }

        [HttpGet]
        public IActionResult ExportUserGameStats(int userId)
        {
            var comlumHeadrs = new string[]
            {
                "Round Number",
                "Practice",
                "Goal Attempt Sequence"
            };

            byte[] result;

            UserGameStats stats = _service.GetUserGameStats(userId);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Game Stats");

                worksheet.Cells[1, 1].Value = "Normal Goals";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Value = stats.Goals;
                worksheet.Cells[1, 3].Value = "Practice Goals";
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Value = stats.PracticeGoals;
                worksheet.Cells[1, 5].Value = "Finished";
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Value = stats.GameFinished;

                using (var cells = worksheet.Cells[2, 1, 2, 5])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < comlumHeadrs.Count(); i++)
                {
                    worksheet.Cells[2, i + 1].Value = comlumHeadrs[i];
                }

                var row = 3;
                var roundNumber = 1;
                foreach (var round in stats.RoundStats)
                {
                    worksheet.Cells[row, 1].Value = roundNumber;
                    worksheet.Cells[row, 2].Value = round.Practice;
                    row++;
                    roundNumber++;

                    foreach (var goalAttempName in round.GoalAttemptRouteNames)
                    {
                        worksheet.Cells[row, 3].Value = goalAttempName;
                        row++;
                    }

                }

                List<Route> routes = _routeService.GetRoutes();

                worksheet.Cells[2, 5].Value = "Sequence";
                worksheet.Cells[2, 5].Style.Font.Bold = true;
                worksheet.Cells[2, 6].Value = "Practice Count";
                worksheet.Cells[2, 6].Style.Font.Bold = true;
                worksheet.Cells[2, 7].Value = "Normal Count";
                worksheet.Cells[2, 7].Style.Font.Bold = true;
                row = 3;
                foreach(Route route in routes)
                {
                    worksheet.Cells[row, 5].Value = route.Name; 
                    worksheet.Cells[row, 6].Value = stats.RoundStats.Where(r => r.Practice).SelectMany(r => r.GoalAttemptRouteNames).Count(r => r == route.Name);
                    worksheet.Cells[row, 7].Value = stats.RoundStats.Where(r => !r.Practice).SelectMany(r => r.GoalAttemptRouteNames).Count(r => r == route.Name);
                    row++;
                }

                result = package.GetAsByteArray();
            }

            return File(result, "application/ms-excel", $"{stats.Username}_game_stats.xlsx");
        }
    }
}
