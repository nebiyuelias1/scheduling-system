using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddLabTypeToCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabTypeId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LabTypeId",
                table: "Courses",
                column: "LabTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_LabTypes_LabTypeId",
                table: "Courses",
                column: "LabTypeId",
                principalTable: "LabTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_LabTypes_LabTypeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LabTypeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LabTypeId",
                table: "Courses");
        }
    }
}
