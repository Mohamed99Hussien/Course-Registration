using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomsTable",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsTable", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "StudentsTable",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StudentAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTable", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "TeachersTable",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeacherAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersTable", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "CoursesTable",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseCapicity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesTable", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_CoursesTable_TeachersTable_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeachersTable",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseTable",
                columns: table => new
                {
                    StudentCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    studentsStudentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseTable", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourseTable_CoursesTable_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesTable",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseTable_StudentsTable_studentsStudentId",
                        column: x => x.studentsStudentId,
                        principalTable: "StudentsTable",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesTable_TeacherId",
                table: "CoursesTable",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTable_CourseId",
                table: "StudentCourseTable",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseTable_studentsStudentId",
                table: "StudentCourseTable",
                column: "studentsStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsTable");

            migrationBuilder.DropTable(
                name: "StudentCourseTable");

            migrationBuilder.DropTable(
                name: "CoursesTable");

            migrationBuilder.DropTable(
                name: "StudentsTable");

            migrationBuilder.DropTable(
                name: "TeachersTable");
        }
    }
}
