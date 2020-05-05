using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class addStartAndEndDateToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                schema: "KickyBall",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                schema: "KickyBall",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "KickyBall",
                table: "Games");
        }
    }
}
