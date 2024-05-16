using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Recruitment.Migrations
{
    /// <inheritdoc />
    public partial class AddVacancyApprovalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubmittedToDirForApproval",
                table: "JobPositionVacancy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmittedToHrForApproval",
                table: "JobPositionVacancy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubmittedToDirForApproval",
                table: "JobPositionVacancy");

            migrationBuilder.DropColumn(
                name: "IsSubmittedToHrForApproval",
                table: "JobPositionVacancy");
        }
    }
}
