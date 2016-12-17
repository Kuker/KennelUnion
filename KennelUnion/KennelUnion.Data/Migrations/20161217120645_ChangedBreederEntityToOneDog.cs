using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KennelUnion.Data.Migrations
{
    public partial class ChangedBreederEntityToOneDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Breeders_BreederId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_BreederId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Breeders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeders_DogId",
                table: "Breeders",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeders_Dogs_DogId",
                table: "Breeders",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeders_Dogs_DogId",
                table: "Breeders");

            migrationBuilder.DropIndex(
                name: "IX_Breeders_DogId",
                table: "Breeders");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Breeders");

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "Dogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreederId",
                table: "Dogs",
                column: "BreederId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Breeders_BreederId",
                table: "Dogs",
                column: "BreederId",
                principalTable: "Breeders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
