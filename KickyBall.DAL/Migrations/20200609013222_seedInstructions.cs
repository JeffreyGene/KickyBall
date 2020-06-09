using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KickyBall",
                table: "ApplicationSettings",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
            migrationBuilder.Sql($@"
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('INSTR', 'Instructions for KickyBall', 'Score as many goals as possible!', 1)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KickyBall",
                table: "ApplicationSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}
