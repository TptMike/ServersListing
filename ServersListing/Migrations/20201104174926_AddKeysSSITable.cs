using Microsoft.EntityFrameworkCore.Migrations;

namespace ServersListing.Migrations
{
    public partial class AddKeysSSITable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerServiceInfo",
                columns: table => new
                {
                    ServerInfoId = table.Column<int>(nullable: false),
                    ServerServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerServiceInfo", x => new { x.ServerInfoId, x.ServerServiceId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerServiceInfo");
        }
    }
}
