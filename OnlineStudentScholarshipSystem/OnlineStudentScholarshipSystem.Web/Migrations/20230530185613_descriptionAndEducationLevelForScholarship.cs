using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStudentScholarshipSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class descriptionAndEducationLevelForScholarship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "Scholarship",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Scholarship");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "Scholarship");
        }
    }
}
