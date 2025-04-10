using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinallyProject.Migrations
{
    /// <inheritdoc />
    public partial class fix_pro_cate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AppCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AppCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AppCategories",
                type: "bigint",
                nullable: true);
        }
    }
}
