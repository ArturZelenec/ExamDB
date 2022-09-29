using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamDB.Migrations
{
    public partial class StatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tracks",
                type: "TEXT",
                nullable: false,
                defaultValue: "Activ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tracks");
        }
    }
}
