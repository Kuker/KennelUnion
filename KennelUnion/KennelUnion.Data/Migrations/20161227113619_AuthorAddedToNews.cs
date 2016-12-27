using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KennelUnion.Data.Migrations
{
    public partial class AuthorAddedToNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "NewsSet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsSet_AuthorId",
                table: "NewsSet",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsSet_AspNetUsers_AuthorId",
                table: "NewsSet",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsSet_AspNetUsers_AuthorId",
                table: "NewsSet");

            migrationBuilder.DropIndex(
                name: "IX_NewsSet_AuthorId",
                table: "NewsSet");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NewsSet");
        }
    }
}
