using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrazyCloset.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ClothesItems");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ArrivedDate",
                table: "ClothesItems",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivedDate",
                table: "ClothesItems");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "ClothesItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
