using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Playgrounds",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Base64Data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Image_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_ImageId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Playgrounds");
        }
    }
}
