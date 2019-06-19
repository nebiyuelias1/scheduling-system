using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameCollegeModelColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_AspNetUsers_DepartmentHeadId",
                table: "Colleges");

            migrationBuilder.RenameColumn(
                name: "DepartmentHeadId",
                table: "Colleges",
                newName: "CollegeDeanId");

            migrationBuilder.RenameIndex(
                name: "IX_Colleges_DepartmentHeadId",
                table: "Colleges",
                newName: "IX_Colleges_CollegeDeanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_AspNetUsers_CollegeDeanId",
                table: "Colleges",
                column: "CollegeDeanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_AspNetUsers_CollegeDeanId",
                table: "Colleges");

            migrationBuilder.RenameColumn(
                name: "CollegeDeanId",
                table: "Colleges",
                newName: "DepartmentHeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Colleges_CollegeDeanId",
                table: "Colleges",
                newName: "IX_Colleges_DepartmentHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_AspNetUsers_DepartmentHeadId",
                table: "Colleges",
                column: "DepartmentHeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
