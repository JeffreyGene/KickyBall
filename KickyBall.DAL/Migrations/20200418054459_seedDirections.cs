﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedDirections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                SET IDENTITY_INSERT KickyBall.Directions ON

                INSERT INTO KickyBall.Directions (DirectionId, Name) VALUES (1, 'L')
                INSERT INTO KickyBall.Directions (DirectionId, Name) VALUES (2, 'R')

                SET IDENTITY_INSERT KickyBall.Directions OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
