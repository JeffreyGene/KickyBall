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

                WITH newFieldPositions (fieldPositionId)
                AS
                (
                    SELECT 1  
                    UNION ALL
                    SELECT fieldPositionId + 1 FROM newFieldPositions WHERE fieldPositionId < 63
                )

                INSERT INTO KickyBall.FieldPositions (FieldPositionId, LeftFieldPositionId, RightFieldPositionId) 
                SELECT fieldPositionId, 
                    CASE WHEN fieldPositionId < 32 THEN fieldPositionId * 2 ELSE NULL END, 
                    CASE WHEN fieldPositionId < 32 THEN fieldPositionId * 2 + 1 ELSE NULL END 
                FROM newFieldPositions

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
