using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddHeadColumnToCollege : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentHeadId",
                table: "Colleges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_DepartmentHeadId",
                table: "Colleges",
                column: "DepartmentHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_AspNetUsers_DepartmentHeadId",
                table: "Colleges",
                column: "DepartmentHeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_AspNetUsers_DepartmentHeadId",
                table: "Colleges");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_DepartmentHeadId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "DepartmentHeadId",
                table: "Colleges");
        }
    }
}
