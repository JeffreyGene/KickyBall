using Microsoft.EntityFrameworkCore.Migrations;

namespace KickyBall.DAL.Migrations
{
    public partial class seedApplicationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('PRT', 'Practice Round Time (Seconds)', '300', 1)
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('RT', 'Round Time (Seconds)', '300', 1)
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('NOPR', 'Number of Practice Rounds', '2', 1)
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('NOR', 'Number of Rounds', '6', 1)
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('URC', 'User Registration Code', 'Hi Hannah!', 1)
                INSERT INTO KickyBall.ApplicationSettings (ApplicationSettingCode, Name, Value, Enabled) VALUES ('ARC', 'Admin Registration Code', 'I am the special.', 1)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
