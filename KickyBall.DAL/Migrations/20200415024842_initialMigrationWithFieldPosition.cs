using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class initialMigrationWithFieldPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KickyBall");

            migrationBuilder.CreateTable(
                name: "FieldPositions",
                schema: "KickyBall",
                columns: table => new
                {
                    FieldPositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftFieldPositionId = table.Column<int>(nullable: true),
                    RightFieldPositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldPositions", x => x.FieldPositionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldPositions",
                schema: "KickyBall");
        }
    }
}
