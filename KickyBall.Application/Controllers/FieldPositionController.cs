using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KickyBall.BLL.Interfaces;
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
    public class FieldPositionController : ControllerBase
    {
        private readonly ILogger<FieldPositionController> _logger;
        private readonly IFieldPositionService _service;

        public FieldPositionController(ILogger<FieldPositionController> logger, IFieldPositionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<FieldPosition> GetFieldPositions()
        {
            return _service.GetFieldPositions();
        }
    }
}
