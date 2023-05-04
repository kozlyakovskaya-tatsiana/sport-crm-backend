using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class removeUnnecessaryRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_SportGroups_SportGroupId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroups_AspNetUsers_InstructorId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_SportGroups_InstructorId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_SportGroupId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "SportGroups");

            migrationBuilder.DropColumn(
                name: "SportGroupId",
                table: "Playgrounds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "SportGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SportGroupId",
                table: "Playgrounds",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportGroups_InstructorId",
                table: "SportGroups",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_SportGroupId",
                table: "Playgrounds",
                column: "SportGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_SportGroups_SportGroupId",
                table: "Playgrounds",
                column: "SportGroupId",
                principalTable: "SportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroups_AspNetUsers_InstructorId",
                table: "SportGroups",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
