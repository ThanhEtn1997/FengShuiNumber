using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FengShuiNumber.Migrations
{
    public partial class UpdatePrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.DropIndex(
                name: "IX_Prefixes_NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.DropColumn(
                name: "NetWorkProviderId",
                table: "Prefixes");

            migrationBuilder.CreateIndex(
                name: "IX_Prefixes_NetWorkId",
                table: "Prefixes",
                column: "NetWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkId",
                table: "Prefixes",
                column: "NetWorkId",
                principalTable: "NetWorkProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkId",
                table: "Prefixes");

            migrationBuilder.DropIndex(
                name: "IX_Prefixes_NetWorkId",
                table: "Prefixes");

            migrationBuilder.AddColumn<Guid>(
                name: "NetWorkProviderId",
                table: "Prefixes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prefixes_NetWorkProviderId",
                table: "Prefixes",
                column: "NetWorkProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prefixes_NetWorkProviders_NetWorkProviderId",
                table: "Prefixes",
                column: "NetWorkProviderId",
                principalTable: "NetWorkProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
