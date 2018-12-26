using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifySectionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdmissionLevelId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgramTypeId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_AdmissionLevelId",
                table: "Sections",
                column: "AdmissionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProgramTypeId",
                table: "Sections",
                column: "ProgramTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AdmissionLevels_AdmissionLevelId",
                table: "Sections",
                column: "AdmissionLevelId",
                principalTable: "AdmissionLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_ProgramTypes_ProgramTypeId",
                table: "Sections",
                column: "ProgramTypeId",
                principalTable: "ProgramTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AdmissionLevels_AdmissionLevelId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_ProgramTypes_ProgramTypeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_AdmissionLevelId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ProgramTypeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "AdmissionLevelId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ProgramTypeId",
                table: "Sections");
        }
    }
}
