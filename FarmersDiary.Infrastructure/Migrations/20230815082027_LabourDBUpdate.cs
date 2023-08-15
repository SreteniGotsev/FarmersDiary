using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersDiary.Data.Migrations
{
    public partial class LabourDBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Labours_LabourId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Labours_Animals_ModerId",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Labours_ModerId",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Animals_LabourId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ModerId",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "LabourId",
                table: "Animals");

            migrationBuilder.CreateTable(
                name: "AnimalLabour",
                columns: table => new
                {
                    LaboursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OffspringsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalLabour", x => new { x.LaboursId, x.OffspringsId });
                    table.ForeignKey(
                        name: "FK_AnimalLabour_Animals_OffspringsId",
                        column: x => x.OffspringsId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalLabour_Labours_LaboursId",
                        column: x => x.LaboursId,
                        principalTable: "Labours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalLabour_OffspringsId",
                table: "AnimalLabour",
                column: "OffspringsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalLabour");

            migrationBuilder.AddColumn<Guid>(
                name: "ModerId",
                table: "Labours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LabourId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labours_ModerId",
                table: "Labours",
                column: "ModerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LabourId",
                table: "Animals",
                column: "LabourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Labours_LabourId",
                table: "Animals",
                column: "LabourId",
                principalTable: "Labours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_Animals_ModerId",
                table: "Labours",
                column: "ModerId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
