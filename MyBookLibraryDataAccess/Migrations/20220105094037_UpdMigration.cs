using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookLibraryDataAccess.Migrations
{
    public partial class UpdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authur",
                table: "Books",
                newName: "Author");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Books",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "Authur");
        }
    }
}
