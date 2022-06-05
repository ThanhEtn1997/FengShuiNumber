using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FengShuiNumber.Migrations
{
    public partial class ModifyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NetWorkProviderId",
                table: "Prefixes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "NetWorkProviders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prefixes_NetWorkProviderId",
                table: "Prefixes",
                column: "NetWorkProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PrefixId",
                table: "PhoneNumbers",
                column: "PrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Prefixes_PrefixId",
                table: "PhoneNumbers",
                column: "PrefixId",
                principalTable: "Prefixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkProviderId",
                table: "Prefixes",
                column: "NetWorkProviderId",
                principalTable: "NetWorkProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Prefixes_PrefixId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.DropIndex(
                name: "IX_Prefixes_NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_PrefixId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "NetWorkProviders");
        }
    }
}
