using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinallyProject.Migrations
{
    /// <inheritdoc />
    public partial class delete_3_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AppProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AppProducts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AppProducts",
                type: "bigint",
                nullable: true);
        }
    }
}
