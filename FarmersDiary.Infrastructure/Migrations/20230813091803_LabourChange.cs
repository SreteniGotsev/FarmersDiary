using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersDiary.Data.Migrations
{
    public partial class LabourChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ModerId",
                table: "Labours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MotherId",
                table: "Labours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Labours_ModerId",
                table: "Labours",
                column: "ModerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_Animals_ModerId",
                table: "Labours",
                column: "ModerId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labours_Animals_ModerId",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Labours_ModerId",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "ModerId",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Labours");
        }
    }
}
