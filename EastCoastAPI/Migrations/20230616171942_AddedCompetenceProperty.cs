using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EastCoastEducation.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompetenceProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Competence",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Competence",
                table: "Teachers");
        }
    }
}
