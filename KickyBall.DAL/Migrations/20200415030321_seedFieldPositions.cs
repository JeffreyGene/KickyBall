using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedFieldPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                SET IDENTITY_INSERT KickyBall.FieldPositions ON

                GO

                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (1, 2, 3)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (2, 4, 5)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (3, 5, 6)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (4, 7, 8)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (5, 8, 9)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (6, 9, 10)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (7, 11, 12)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (8, 12, 13)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (9, 13, 14)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (10, 14, 15)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (11, 16, 17)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (12, 17, 18)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (13, 18, 19)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (14, 19, 20)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (15, 20, 21)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (16, NULL, NULL)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (17, NULL, NULL)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (18, NULL, NULL)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (19, NULL, NULL)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (20, NULL, NULL)
                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) VALUES (21, NULL, NULL)

                GO

                SET IDENTITY_INSERT KickyBall.FieldPositions OFF

                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
