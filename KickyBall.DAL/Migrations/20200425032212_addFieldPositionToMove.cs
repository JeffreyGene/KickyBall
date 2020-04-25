using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class addFieldPositionToMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldPositionId",
                schema: "KickyBall",
                table: "Moves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_FieldPositionId",
                schema: "KickyBall",
                table: "Moves",
                column: "FieldPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_FieldPositions_FieldPositionId",
                schema: "KickyBall",
                table: "Moves",
                column: "FieldPositionId",
                principalSchema: "KickyBall",
                principalTable: "FieldPositions",
                principalColumn: "FieldPositionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_FieldPositions_FieldPositionId",
                schema: "KickyBall",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_FieldPositionId",
                schema: "KickyBall",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "FieldPositionId",
                schema: "KickyBall",
                table: "Moves");
        }
    }
}
