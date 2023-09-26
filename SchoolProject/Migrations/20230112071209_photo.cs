using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photoName",
                table: "StudentsTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoName",
                table: "StudentsTable");
        }
    }
}
