using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EastCoastEducation.Migrations
{
    /// <inheritdoc />
    public partial class removalOfCategoryConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseNumber_CourseTitle_Category",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseNumber_CourseTitle",
                table: "Courses",
                columns: new[] { "CourseNumber", "CourseTitle" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseNumber_CourseTitle",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseNumber_CourseTitle_Category",
                table: "Courses",
                columns: new[] { "CourseNumber", "CourseTitle", "Category" },
                unique: true);
        }
    }
}
