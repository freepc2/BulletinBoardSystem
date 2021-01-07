using Microsoft.EntityFrameworkCore.Migrations;

namespace Bbs.MSSQL.DAL.Migrations
{
    public partial class bbs001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Notes");
        }
    }
}
