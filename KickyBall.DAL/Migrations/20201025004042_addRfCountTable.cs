using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class addRfCountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                DELETE FROM KickyBall.ApplicationSettings WHERE ApplicationSettingCode='INSTR'
            ");
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "KickyBall",
                table: "ApplicationSettings",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KickyBall",
                table: "ApplicationSettings",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "RfCountToRouteAndGame",
                schema: "KickyBall",
                columns: table => new
                {
                    RfCountToRouteAndGameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfCountToRouteAndGame", x => x.RfCountToRouteAndGameId);
                    table.ForeignKey(
                        name: "FK_RfCountToRouteAndGame_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "KickyBall",
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfCountToRouteAndGame_Routes_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "KickyBall",
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfCountToRouteAndGame_GameId",
                schema: "KickyBall",
                table: "RfCountToRouteAndGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_RfCountToRouteAndGame_RouteId",
                schema: "KickyBall",
                table: "RfCountToRouteAndGame",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfCountToRouteAndGame",
                schema: "KickyBall");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "KickyBall",
                table: "ApplicationSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KickyBall",
                table: "ApplicationSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
