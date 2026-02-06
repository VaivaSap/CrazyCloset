using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrazyCloset.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ClothesItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastWornDate",
                table: "ClothesItems",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ClothesItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WearingCount",
                table: "ClothesItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ClothesItems");

            migrationBuilder.DropColumn(
                name: "LastWornDate",
                table: "ClothesItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ClothesItems");

            migrationBuilder.DropColumn(
                name: "WearingCount",
                table: "ClothesItems");
        }
    }
}
