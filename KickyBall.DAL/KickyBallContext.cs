using KickyBall.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KickyBall.DAL
{
    public class KickyBallContext : DbContext
    {
        public DbSet<FieldPosition> FieldPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KickyBall;Trusted_Connection=True;");
    }
}
