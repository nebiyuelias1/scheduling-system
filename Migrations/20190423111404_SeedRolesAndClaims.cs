using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedRolesAndClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1b7c5d6a-3979-4626-a624-23ff6737b5de', N'College Dean', N'COLLEGE DEAN', N'5ab9553e-110e-445f-bcc3-c115390b4b5e')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'237d32d8-3d71-4967-9ec5-c9c3ef51ffc4', N'Student', N'STUDENT', N'92e10f8a-58ec-4fdd-993d-c7f25fd42131')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'27c1fa7a-6c59-409c-a971-0d5bb42c7ec4', N'Administrator', N'ADMINISTRATOR', N'316a950d-613a-4ef8-8466-002c6f5508ea')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'523da078-2498-4dde-99c7-53c09318c1fc', N'Lab Assistant', N'LAB ASSISTANT', N'59aa3416-dbb6-4725-8adc-4377dc1fbcd9')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c6a26237-5280-4a22-8464-dd2d93b92d7d', N'Department Head', N'DEPARTMENT HEAD', N'8d76562d-c778-46d7-8d97-987a5353cc62')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e54d9685-3099-4c6a-a53f-b7ca03c56f71', N'Instructor', N'INSTRUCTOR', N'3529381e-b5a4-4612-8bfa-aa85b612b0de')");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] ON");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (1, N'27c1fa7a-6c59-409c-a971-0d5bb42c7ec4', N'admin', N'true')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (7, N'1b7c5d6a-3979-4626-a624-23ff6737b5de', N'dean', N'true')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (9, N'c6a26237-5280-4a22-8464-dd2d93b92d7d', N'head', N'true')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (11, N'237d32d8-3d71-4967-9ec5-c9c3ef51ffc4', N'student', N'true')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (12, N'523da078-2498-4dde-99c7-53c09318c1fc', N'assistant', N'true')");
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (13, N'e54d9685-3099-4c6a-a53f-b7ca03c56f71', N'instructor', N'true')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles] WHERE Id IN ('1b7c5d6a-3979-4626-a624-23ff6737b5de', '237d32d8-3d71-4967-9ec5-c9c3ef51ffc4', '27c1fa7a-6c59-409c-a971-0d5bb42c7ec4', '523da078-2498-4dde-99c7-53c09318c1fc', 'c6a26237-5280-4a22-8464-dd2d93b92d7d', 'e54d9685-3099-4c6a-a53f-b7ca03c56f71')");
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoleClaims] WHERE Id IN (1, 7, 9, 11, 12, 13)");
        }
    }
}
