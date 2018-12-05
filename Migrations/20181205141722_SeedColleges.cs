using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedColleges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Health Science')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Medicine')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Engineering')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Computing')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Natural and Computational Science')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Agriculture and Natural Resource Science')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Education')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Law')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Business and Economics')");
            migrationBuilder.Sql("INSERT INTO Colleges (Name) VALUES ('College of Social Science and Humanities')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETERE FROM Colleges WHERE Name IN (
                'College of Health Science',
                'College of Medicine',
                'College of Engineering',
                'College of Computing',
                'College of Natural and Computational Science',
                'College of Agriculture and Natural Resource Science',
                'College of Education',
                'College of Law',
                'College of Business and Economics',
                'College of Social Science and Humanities')");
        }
    }
}
