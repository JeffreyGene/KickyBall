using KickyBall.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KickyBall.DAL
{
    public class KickyBallContext : DbContext
    {
        public DbSet<Direction> Directions { get; set; }
        public DbSet<FieldPosition> FieldPositions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GoalAttempt> GoalAttempts { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Round> Rounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KickyBall;Trusted_Connection=True;");
    }
}

