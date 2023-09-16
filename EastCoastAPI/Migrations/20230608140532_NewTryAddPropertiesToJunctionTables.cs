using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EastCoastEducation.Migrations
{
    /// <inheritdoc />
    public partial class NewTryAddPropertiesToJunctionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersCompetences",
                table: "TeachersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_TeachersCompetences_TeacherId",
                table: "TeachersCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourses_StudentId",
                table: "StudentsCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersCompetences",
                table: "TeachersCompetences",
                columns: new[] { "TeacherId", "CompetenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCompetence",
                columns: table => new
                {
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetencesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCompetence", x => new { x.TeachersId, x.CompetencesId });
                    table.ForeignKey(
                        name: "FK_TeacherCompetence_Competences_CompetencesId",
                        column: x => x.CompetencesId,
                        principalTable: "Competences",
                        principalColumn: "CompetenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCompetence_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachersCompetences_CompetenceId",
                table: "TeachersCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CoursesId",
                table: "StudentCourse",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCompetence_CompetencesId",
                table: "TeacherCompetence",
                column: "CompetencesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "TeacherCompetence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersCompetences",
                table: "TeachersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_TeachersCompetences_CompetenceId",
                table: "TeachersCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersCompetences",
                table: "TeachersCompetences",
                columns: new[] { "CompetenceId", "TeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeachersCompetences_TeacherId",
                table: "TeachersCompetences",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_StudentId",
                table: "StudentsCourses",
                column: "StudentId");
        }
    }
}
