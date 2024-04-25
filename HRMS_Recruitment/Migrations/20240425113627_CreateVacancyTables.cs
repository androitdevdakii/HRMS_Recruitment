using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Recruitment.Migrations
{
    /// <inheritdoc />
    public partial class CreateVacancyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desccription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosition_JobDepartment_JobDepartmentId",
                        column: x => x.JobDepartmentId,
                        principalTable: "JobDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPositionJobTask",
                columns: table => new
                {
                    JobPositionsId = table.Column<int>(type: "int", nullable: false),
                    JobTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositionJobTask", x => new { x.JobPositionsId, x.JobTasksId });
                    table.ForeignKey(
                        name: "FK_JobPositionJobTask_JobPosition_JobPositionsId",
                        column: x => x.JobPositionsId,
                        principalTable: "JobPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPositionJobTask_JobTask_JobTasksId",
                        column: x => x.JobTasksId,
                        principalTable: "JobTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_JobDepartmentId",
                table: "JobPosition",
                column: "JobDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositionJobTask_JobTasksId",
                table: "JobPositionJobTask",
                column: "JobTasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPositionJobTask");

            migrationBuilder.DropTable(
                name: "JobPosition");

            migrationBuilder.DropTable(
                name: "JobTask");

            migrationBuilder.DropTable(
                name: "JobDepartment");
        }
    }
}
