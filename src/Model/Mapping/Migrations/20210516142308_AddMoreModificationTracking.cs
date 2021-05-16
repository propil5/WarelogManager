using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarelogManager.Model.Mapping.Migrations
{
    public partial class AddMoreModificationTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedById",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedDate",
                table: "InventoryItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "InventoryItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_EditedById",
                table: "Product",
                column: "EditedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_EditedById",
                table: "Product",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_EditedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_EditedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "InventoryItem");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedDate",
                table: "InventoryItem",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedById",
                table: "Product",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedById",
                table: "Product",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
