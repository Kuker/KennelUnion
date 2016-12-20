using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KennelUnion.Data.Migrations
{
    public partial class AddedLitterOverviewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Dogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Breeders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Abouts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LitterOverviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Father = table.Column<string>(nullable: true),
                    FatherRegistrationNumber = table.Column<string>(nullable: true),
                    MatingDate = table.Column<DateTime>(nullable: false),
                    Mother = table.Column<string>(nullable: true),
                    MotherRegistrationNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LitterOverviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chip = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LitterOverviewId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pups_LitterOverviews_LitterOverviewId",
                        column: x => x.LitterOverviewId,
                        principalTable: "LitterOverviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pups_LitterOverviewId",
                table: "Pups",
                column: "LitterOverviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pups");

            migrationBuilder.DropTable(
                name: "LitterOverviews");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Breeders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Abouts");
        }
    }
}
