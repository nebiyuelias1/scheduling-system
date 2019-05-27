using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class MakeColumnsInInstructorAssignmentNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_Instructors_InstructorId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorAssignments",
                table: "InstructorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "InstructorAssignments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "InstructorAssignments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CourseOfferingId",
                table: "InstructorAssignments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InstructorAssignments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorAssignments",
                table: "InstructorAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAssignments_CourseOfferingId",
                table: "InstructorAssignments",
                column: "CourseOfferingId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_Instructors_InstructorId",
                table: "InstructorAssignments",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_Instructors_InstructorId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorAssignments",
                table: "InstructorAssignments");

            migrationBuilder.DropIndex(
                name: "IX_InstructorAssignments_CourseOfferingId",
                table: "InstructorAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InstructorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "InstructorAssignments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "InstructorAssignments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseOfferingId",
                table: "InstructorAssignments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorAssignments",
                table: "InstructorAssignments",
                columns: new[] { "CourseOfferingId", "InstructorId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_Instructors_InstructorId",
                table: "InstructorAssignments",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
