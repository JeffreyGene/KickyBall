using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                SET IDENTITY_INSERT KickyBall.Routes ON

                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (1, 'RRRRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (2, 'RRRRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (3, 'RRRLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (4, 'RRRLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (5, 'RRLRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (6, 'RRLRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (7, 'RRLLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (8, 'RRLLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (9, 'RLRRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (10, 'RLRRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (11, 'RLRLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (12, 'RLRLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (13, 'RLLRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (14, 'RLLRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (15, 'RLLLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (16, 'RLLLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (17, 'LRRRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (18, 'LRRRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (19, 'LRRLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (20, 'LRRLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (21, 'LRLRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (22, 'LRLRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (23, 'LRLLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (24, 'LRLLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (25, 'LLRRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (26, 'LLRRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (27, 'LLRLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (28, 'LLRLL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (29, 'LLLRR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (30, 'LLLRL')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (31, 'LLLLR')
                INSERT INTO KickyBall.Routes (RouteId, Name) VALUES (32, 'LLLLL')

                SET IDENTITY_INSERT KickyBall.Routes OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
