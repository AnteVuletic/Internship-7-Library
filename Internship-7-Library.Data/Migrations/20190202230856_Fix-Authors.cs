using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship_7_Library.Data.Migrations
{
    public partial class FixAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Persons_PersonId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "MonthlyBookLimit",
                table: "Subscribers");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Authors",
                newName: "AuthorPersonPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_PersonId",
                table: "Authors",
                newName: "IX_Authors_AuthorPersonPersonId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Persons_AuthorPersonPersonId",
                table: "Authors",
                column: "AuthorPersonPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Persons_AuthorPersonPersonId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorPersonPersonId",
                table: "Authors",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_AuthorPersonPersonId",
                table: "Authors",
                newName: "IX_Authors_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "MonthlyBookLimit",
                table: "Subscribers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Persons_PersonId",
                table: "Authors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
