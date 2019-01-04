using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifyAcademicYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicSemesters_AcademicYear_AcademicYearId",
                table: "AcademicSemesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear");

            migrationBuilder.RenameTable(
                name: "AcademicYear",
                newName: "AcademicYears");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicSemesters_AcademicYears_AcademicYearId",
                table: "AcademicSemesters",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicSemesters_AcademicYears_AcademicYearId",
                table: "AcademicSemesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears");

            migrationBuilder.RenameTable(
                name: "AcademicYears",
                newName: "AcademicYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicSemesters_AcademicYear_AcademicYearId",
                table: "AcademicSemesters",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
