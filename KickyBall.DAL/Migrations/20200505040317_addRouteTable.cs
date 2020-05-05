using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class addRouteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                schema: "KickyBall",
                table: "GoalAttempts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "KickyBall",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoalAttempts_RouteId",
                schema: "KickyBall",
                table: "GoalAttempts",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalAttempts_Routes_RouteId",
                schema: "KickyBall",
                table: "GoalAttempts",
                column: "RouteId",
                principalSchema: "KickyBall",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalAttempts_Routes_RouteId",
                schema: "KickyBall",
                table: "GoalAttempts");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "KickyBall");

            migrationBuilder.DropIndex(
                name: "IX_GoalAttempts_RouteId",
                schema: "KickyBall",
                table: "GoalAttempts");

            migrationBuilder.DropColumn(
                name: "RouteId",
                schema: "KickyBall",
                table: "GoalAttempts");
        }
    }
}
