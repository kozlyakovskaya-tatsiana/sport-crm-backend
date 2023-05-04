using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportActivitySportPlayground_Playgrounds_SuitablePlayground~",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropIndex(
                name: "IX_SportActivitySportPlayground_SuitablePlaygroundsId",
                table: "SportActivitySportPlayground");

            migrationBuilder.RenameColumn(
                name: "SuitablePlaygroundsId",
                table: "SportActivitySportPlayground",
                newName: "SportPlaygroundsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground",
                columns: new[] { "SportPlaygroundsId", "SuitableActivitiesId" });

            migrationBuilder.CreateIndex(
                name: "IX_SportActivitySportPlayground_SuitableActivitiesId",
                table: "SportActivitySportPlayground",
                column: "SuitableActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportActivitySportPlayground_Playgrounds_SportPlaygroundsId",
                table: "SportActivitySportPlayground",
                column: "SportPlaygroundsId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportActivitySportPlayground_Playgrounds_SportPlaygroundsId",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropIndex(
                name: "IX_SportActivitySportPlayground_SuitableActivitiesId",
                table: "SportActivitySportPlayground");

            migrationBuilder.RenameColumn(
                name: "SportPlaygroundsId",
                table: "SportActivitySportPlayground",
                newName: "SuitablePlaygroundsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground",
                columns: new[] { "SuitableActivitiesId", "SuitablePlaygroundsId" });

            migrationBuilder.CreateIndex(
                name: "IX_SportActivitySportPlayground_SuitablePlaygroundsId",
                table: "SportActivitySportPlayground",
                column: "SuitablePlaygroundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportActivitySportPlayground_Playgrounds_SuitablePlayground~",
                table: "SportActivitySportPlayground",
                column: "SuitablePlaygroundsId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
