using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class changeMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "SportGroupMember");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "SportGroupMember",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SportGroupMember",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "SportGroupMember",
                type: "text",
                nullable: true);
        }
    }
}
