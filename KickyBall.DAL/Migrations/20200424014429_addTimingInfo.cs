using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class addTimingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                schema: "KickyBall",
                table: "Rounds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Practice",
                schema: "KickyBall",
                table: "Rounds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SecondsRemaining",
                schema: "KickyBall",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                schema: "KickyBall",
                table: "Games",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                schema: "KickyBall",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Practice",
                schema: "KickyBall",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "SecondsRemaining",
                schema: "KickyBall",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Finished",
                schema: "KickyBall",
                table: "Games");
        }
    }
}
