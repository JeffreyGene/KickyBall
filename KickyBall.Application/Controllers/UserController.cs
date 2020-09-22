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

            byte[] result;

            UserGameStats stats = _service.GetUserGameStats(userId);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Game Stats");

                worksheet.Cells[1, 1].Value = "Participant ID";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[2, 1].Value = stats.Username;

                worksheet.Cells[1, 2].Value = "Round Number";
                worksheet.Cells[1, 2].Style.Font.Bold = true;

                worksheet.Cells[1, 3].Value = "Phase";
                worksheet.Cells[1, 3].Style.Font.Bold = true;

                worksheet.Cells[1, 4].Value = "Goal Attempt";
                worksheet.Cells[1, 4].Style.Font.Bold = true;

                worksheet.Cells[1, 5].Value = "Sequence";
                worksheet.Cells[1, 5].Style.Font.Bold = true;

                worksheet.Cells[1, 6].Value = "Prob Count";
                worksheet.Cells[1, 6].Style.Font.Bold = true;

                worksheet.Cells[1, 7].Value = "Var Count";
                worksheet.Cells[1, 7].Style.Font.Bold = true;

                worksheet.Cells[1, 8].Value = "Prob Attempt";
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Cells[2, 8].Value = stats.PracticeAttempts;


                worksheet.Cells[1, 9].Value = "Prob Goal";
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[2, 9].Value = stats.PracticeGoals;

                worksheet.Cells[1, 10].Value = "Var Attempt";
                worksheet.Cells[1, 10].Style.Font.Bold = true;
                worksheet.Cells[2, 10].Value = stats.NormalAttempts;

                worksheet.Cells[1, 11].Value = "Var Count";
                worksheet.Cells[1, 11].Style.Font.Bold = true;
                worksheet.Cells[2, 11].Value = stats.NormalGoals;

                worksheet.Cells[1, 12].Value = "Finished";
                worksheet.Cells[1, 12].Style.Font.Bold = true;
                worksheet.Cells[2, 12].Value = stats.GameFinished;

                var row = 2;
                var roundNumber = 1;
                foreach (var round in stats.RoundStats)
                {

                    foreach (var goalAttempName in round.GoalAttemptRouteNames)
                    {
                        worksheet.Cells[row, 2].Value = roundNumber;
                        worksheet.Cells[row, 3].Value = round.Practice ? "PROB" : "VAR";
                        worksheet.Cells[row, 4].Value = goalAttempName;
                        row++;
                    }
                    roundNumber++;

                }

                List<Route> routes = _routeService.GetRoutes();
                row = 2;
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
