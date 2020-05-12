using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class updateSeededChoiceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                UPDATE KickyBall.FieldPositions SET ChoiceNumber = CASE 
                    WHEN FieldPositionId = 1 THEN 0 
                    WHEN FieldPositionId > 1 and FieldPositionId < 4 THEN 1 
                    WHEN FieldPositionId > 3 and FieldPositionId < 7 THEN 2 
                    WHEN FieldPositionId > 6 and FieldPositionId < 11 THEN 3 
                    WHEN FieldPositionId > 10 and FieldPositionId < 16 THEN 4 
                    WHEN FieldPositionId > 15 and FieldPositionId < 22 THEN 5
                    ELSE 6 END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
