using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetService.DataAccess.Migrations
{
    public partial class UpdatePlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Planets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Planets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Planets");
        }
    }
}
