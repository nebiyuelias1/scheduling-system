using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Departments (Name, CollegeId) VALUES ('Software Engineering', (SELECT Id FROM Colleges WHERE Name = 'College of Computing'))");
            migrationBuilder.Sql("INSERT INTO Departments (Name, CollegeId) VALUES ('Computer Science', (SELECT Id FROM Colleges WHERE Name = 'College of Computing'))");
            migrationBuilder.Sql("INSERT INTO Departments (Name, CollegeId) VALUES ('Information Technology', (SELECT Id FROM Colleges WHERE Name = 'College of Computing'))");
            migrationBuilder.Sql("INSERT INTO Departments (Name, CollegeId) VALUES ('Information Systems', (SELECT Id FROM Colleges WHERE Name = 'College of Computing'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Departments WHERE Name IN (
                            'Software Engineering',
                            'Computer Science',
                            'Information Technology',
                            'Information Systems')");
        }
    }
}
