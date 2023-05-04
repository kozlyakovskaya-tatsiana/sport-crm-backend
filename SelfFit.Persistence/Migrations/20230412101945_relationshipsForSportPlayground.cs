using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class relationshipsForSportPlayground : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Image_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroups_Playgrounds_SportPlaygroundId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_SportGroups_SportPlaygroundId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "SportPlaygroundId",
                table: "SportGroups");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Playgrounds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SportGroupId",
                table: "Playgrounds",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_ImageId",
                table: "Playgrounds",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_SportGroupId",
                table: "Playgrounds",
                column: "SportGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Image_ImageId",
                table: "Playgrounds",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_SportGroups_SportGroupId",
                table: "Playgrounds",
                column: "SportGroupId",
                principalTable: "SportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Image_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_SportGroups_SportGroupId",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_SportGroupId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "SportGroupId",
                table: "Playgrounds");

            migrationBuilder.AddColumn<Guid>(
                name: "SportPlaygroundId",
                table: "SportGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Playgrounds",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_SportGroups_SportPlaygroundId",
                table: "SportGroups",
                column: "SportPlaygroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_ImageId",
                table: "Playgrounds",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Image_ImageId",
                table: "Playgrounds",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroups_Playgrounds_SportPlaygroundId",
                table: "SportGroups",
                column: "SportPlaygroundId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
