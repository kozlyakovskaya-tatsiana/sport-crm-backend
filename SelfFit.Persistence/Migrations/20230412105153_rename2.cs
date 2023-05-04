using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class rename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportActivitySportPlayground_Activities_SuitableActivitiesId",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropIndex(
                name: "IX_SportActivitySportPlayground_SuitableActivitiesId",
                table: "SportActivitySportPlayground");

            migrationBuilder.RenameColumn(
                name: "SuitableActivitiesId",
                table: "SportActivitySportPlayground",
                newName: "SportActivitiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground",
                columns: new[] { "SportActivitiesId", "SportPlaygroundsId" });

            migrationBuilder.CreateIndex(
                name: "IX_SportActivitySportPlayground_SportPlaygroundsId",
                table: "SportActivitySportPlayground",
                column: "SportPlaygroundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportActivitySportPlayground_Activities_SportActivitiesId",
                table: "SportActivitySportPlayground",
                column: "SportActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportActivitySportPlayground_Activities_SportActivitiesId",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground");

            migrationBuilder.DropIndex(
                name: "IX_SportActivitySportPlayground_SportPlaygroundsId",
                table: "SportActivitySportPlayground");

            migrationBuilder.RenameColumn(
                name: "SportActivitiesId",
                table: "SportActivitySportPlayground",
                newName: "SuitableActivitiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportActivitySportPlayground",
                table: "SportActivitySportPlayground",
                columns: new[] { "SportPlaygroundsId", "SuitableActivitiesId" });

            migrationBuilder.CreateIndex(
                name: "IX_SportActivitySportPlayground_SuitableActivitiesId",
                table: "SportActivitySportPlayground",
                column: "SuitableActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportActivitySportPlayground_Activities_SuitableActivitiesId",
                table: "SportActivitySportPlayground",
                column: "SuitableActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
