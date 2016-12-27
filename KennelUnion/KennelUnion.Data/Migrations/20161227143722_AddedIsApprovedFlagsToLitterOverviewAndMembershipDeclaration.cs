using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KennelUnion.Data.Migrations
{
    public partial class AddedIsApprovedFlagsToLitterOverviewAndMembershipDeclaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "MembershipDeclarations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "LitterOverviews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "MembershipDeclarations");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "LitterOverviews");
        }
    }
}
