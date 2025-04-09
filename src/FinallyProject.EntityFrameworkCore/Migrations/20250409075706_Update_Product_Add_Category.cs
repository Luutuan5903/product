using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinallyProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_Product_Add_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "AppProducts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AppProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_CategoryId",
                table: "AppProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId",
                table: "AppProducts",
                column: "CategoryId",
                principalTable: "AppCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId",
                table: "AppProducts");

            migrationBuilder.DropTable(
                name: "AppCategories");

            migrationBuilder.DropIndex(
                name: "IX_AppProducts_CategoryId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppProducts");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AppProducts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
