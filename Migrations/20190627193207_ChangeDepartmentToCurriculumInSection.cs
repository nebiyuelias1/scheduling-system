using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ChangeDepartmentToCurriculumInSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Departments_DepartmentId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Sections",
                newName: "CurriculumId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_DepartmentId",
                table: "Sections",
                newName: "IX_Sections_CurriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Curriculums_CurriculumId",
                table: "Sections",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Curriculums_CurriculumId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "CurriculumId",
                table: "Sections",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CurriculumId",
                table: "Sections",
                newName: "IX_Sections_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Departments_DepartmentId",
                table: "Sections",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
