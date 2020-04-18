using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedGameStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directions",
                schema: "KickyBall",
                columns: table => new
                {
                    DirectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.DirectionId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "KickyBall",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "KickyBall",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "KickyBall",
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                schema: "KickyBall",
                columns: table => new
                {
                    RoundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "KickyBall",
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalAttempts",
                schema: "KickyBall",
                columns: table => new
                {
                    GoalAttemptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalAttempts", x => x.GoalAttemptId);
                    table.ForeignKey(
                        name: "FK_GoalAttempts_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalSchema: "KickyBall",
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                schema: "KickyBall",
                columns: table => new
                {
                    MoveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalAttemptId = table.Column<int>(nullable: false),
                    Ordinal = table.Column<int>(nullable: false),
                    DirectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_Moves_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalSchema: "KickyBall",
                        principalTable: "Directions",
                        principalColumn: "DirectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moves_GoalAttempts_GoalAttemptId",
                        column: x => x.GoalAttemptId,
                        principalSchema: "KickyBall",
                        principalTable: "GoalAttempts",
                        principalColumn: "GoalAttemptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PersonId",
                schema: "KickyBall",
                table: "Games",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalAttempts_RoundId",
                schema: "KickyBall",
                table: "GoalAttempts",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_DirectionId",
                schema: "KickyBall",
                table: "Moves",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GoalAttemptId",
                schema: "KickyBall",
                table: "Moves",
                column: "GoalAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                schema: "KickyBall",
                table: "Rounds",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves",
                schema: "KickyBall");

            migrationBuilder.DropTable(
                name: "Directions",
                schema: "KickyBall");

            migrationBuilder.DropTable(
                name: "GoalAttempts",
                schema: "KickyBall");

            migrationBuilder.DropTable(
                name: "Rounds",
                schema: "KickyBall");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "KickyBall");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "KickyBall");
        }
    }
}
