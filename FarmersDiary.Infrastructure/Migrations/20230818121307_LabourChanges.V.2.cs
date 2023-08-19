using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersDiary.Data.Migrations
{
    public partial class LabourChangesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Father",
                table: "Labours");

            migrationBuilder.AddColumn<Guid>(
                name: "FatherId",
                table: "Labours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Labours");

            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "Labours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
