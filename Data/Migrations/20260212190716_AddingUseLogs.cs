using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrazyCloset.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUseLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWornDate",
                table: "ClothesItems");

            migrationBuilder.DropColumn(
                name: "WearingCount",
                table: "ClothesItems");

            migrationBuilder.CreateTable(
                name: "UseLogs",
                columns: table => new
                {
                    UseLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UsedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseLogs", x => x.UseLogId);
                    table.ForeignKey(
                        name: "FK_UseLogs_ClothesItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ClothesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UseLogs_ItemId",
                table: "UseLogs",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UseLogs");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastWornDate",
                table: "ClothesItems",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WearingCount",
                table: "ClothesItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
