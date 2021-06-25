using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseLibraryAPI.Migrations
{
    public partial class AddDateOfReBornAndDateOfDeathToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfDeath",
                table: "Authors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfReBorn",
                table: "Authors",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "DateOfReBorn",
                table: "Authors");
        }
    }
}
