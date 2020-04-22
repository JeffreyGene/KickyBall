using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class switchToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Persons_PersonId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "KickyBall");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "KickyBall",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_PersonId",
                schema: "KickyBall",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "KickyBall");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "KickyBall",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_PersonId",
                schema: "KickyBall",
                table: "Games",
                column: "PersonId",
                principalSchema: "KickyBall",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
