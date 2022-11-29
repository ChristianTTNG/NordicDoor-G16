using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorApplication.Migrations
{
    public partial class AdminForAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedUserRoles(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('780c74f6-3f34-4b6d-b1b3-a2da5970c0f7', 'a42410b5 - 417f - 4680 - 8c42-c7268d521202');");
        }
    }
}
