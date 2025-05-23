﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinallyProject.Migrations
{
    /// <inheritdoc />
    public partial class fix_table_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppCategories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
