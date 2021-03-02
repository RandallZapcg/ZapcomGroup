using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationAppAPI.Data.Migrations
{
    public partial class upd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "messengers",
                newName: "ChannelName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChannelName",
                table: "messengers",
                newName: "Name");
        }
    }
}
