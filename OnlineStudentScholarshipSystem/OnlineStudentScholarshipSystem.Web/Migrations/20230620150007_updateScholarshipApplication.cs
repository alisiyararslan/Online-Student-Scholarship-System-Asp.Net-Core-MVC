using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStudentScholarshipSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class updateScholarshipApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ScholarshipApplication",
                newName: "ScholarshipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScholarshipId",
                table: "ScholarshipApplication",
                newName: "CompanyId");
        }
    }
}
