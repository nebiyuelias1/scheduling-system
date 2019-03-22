using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddDurationsPropertyToScheduleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ScheduleConfigurationAdmissionLevelId = table.Column<int>(nullable: true),
                    ScheduleConfigurationProgramTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duration_ScheduleConfigurations_ScheduleConfigurationAdmissionLevelId_ScheduleConfigurationProgramTypeId",
                        columns: x => new { x.ScheduleConfigurationAdmissionLevelId, x.ScheduleConfigurationProgramTypeId },
                        principalTable: "ScheduleConfigurations",
                        principalColumns: new[] { "AdmissionLevelId", "ProgramTypeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duration_ScheduleConfigurationAdmissionLevelId_ScheduleConfigurationProgramTypeId",
                table: "Duration",
                columns: new[] { "ScheduleConfigurationAdmissionLevelId", "ScheduleConfigurationProgramTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duration");
        }
    }
}
