using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IRouteService
    {
        List<Route> GetRoutes();
    }
}
