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
    public class FieldPositionService: IFieldPositionService
    {
        private KickyBallContext _context;
        public FieldPositionService(KickyBallContext context)
        {
            _context = context;
        }

        public List<FieldPosition> GetFieldPositions()
        {
            return _context.FieldPositions.OrderByDescending(p => p.FieldPositionId).ToList();
        }
    }
}
