using KickyBall.BLL.Interfaces;
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
    public class RouteService: IRouteService
    {
        private KickyBallContext _context;
        public RouteService(KickyBallContext context)
        {
            _context = context;
        }

        public List<Route> GetRoutes()
        {
            return _context.Routes.OrderBy(r => r.RouteId).ToList();
        }
    }
}
