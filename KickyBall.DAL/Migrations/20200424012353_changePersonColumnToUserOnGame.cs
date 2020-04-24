using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class changePersonColumnToUserOnGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_PersonId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PersonId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "KickyBall",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                schema: "KickyBall",
                table: "Games",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                schema: "KickyBall",
                table: "Games",
                column: "UserId",
                principalSchema: "KickyBall",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "KickyBall",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PersonId",
                schema: "KickyBall",
                table: "Games",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_PersonId",
                schema: "KickyBall",
                table: "Games",
                column: "PersonId",
                principalSchema: "KickyBall",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
