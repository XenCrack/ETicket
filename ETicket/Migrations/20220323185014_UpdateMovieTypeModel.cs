using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETicket.Migrations
{
    public partial class UpdateMovieTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MovieTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MovieTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MovieTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "MovieTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MovieTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MovieTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MovieTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MovieTypes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "MovieTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieTypes");
        }
    }
}
