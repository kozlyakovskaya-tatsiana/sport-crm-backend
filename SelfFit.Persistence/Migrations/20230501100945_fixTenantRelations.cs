using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfFit.Persistence.Migrations
{
    public partial class fixTenantRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Tenants_TenantId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroupMember_SportGroups_SportGroupId",
                table: "SportGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroups_Activities_SportActivityId",
                table: "SportGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroups_Contracts_ContractId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_SportGroups_ContractId",
                table: "SportGroups");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "SportGroups");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Tenants",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ContractId",
                table: "Tenants",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroupMember_SportGroups_SportGroupId",
                table: "SportGroupMember",
                column: "SportGroupId",
                principalTable: "SportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroups_Activities_SportActivityId",
                table: "SportGroups",
                column: "SportActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Contracts_ContractId",
                table: "Tenants",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportGroupMember_SportGroups_SportGroupId",
                table: "SportGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_SportGroups_Activities_SportActivityId",
                table: "SportGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Contracts_ContractId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ContractId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Tenants");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "SportGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportGroups_ContractId",
                table: "SportGroups",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Tenants_TenantId",
                table: "Contracts",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroupMember_SportGroups_SportGroupId",
                table: "SportGroupMember",
                column: "SportGroupId",
                principalTable: "SportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroups_Activities_SportActivityId",
                table: "SportGroups",
                column: "SportActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportGroups_Contracts_ContractId",
                table: "SportGroups",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
