using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarelogManager.Model.Mapping.Migrations
{
    public partial class AddModificationMonitoringToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AspNetUsers_AddedById1",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EditedById1",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_AddedById1",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_EditedById1",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "AddedById1",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "EditedById1",
                table: "InventoryItem");

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EditedById",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedById",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "InventoryItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AddedById",
                table: "Product",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedById",
                table: "Product",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_AddedById",
                table: "InventoryItem",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_EditedById",
                table: "InventoryItem",
                column: "EditedById");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AspNetUsers_AddedById",
                table: "InventoryItem",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EditedById",
                table: "InventoryItem",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_AddedById",
                table: "Product",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedById",
                table: "Product",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AspNetUsers_AddedById",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EditedById",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_AddedById",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AddedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_AddedById",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_EditedById",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "InventoryItem");

            migrationBuilder.AlterColumn<int>(
                name: "EditedById",
                table: "InventoryItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddedById",
                table: "InventoryItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedById1",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById1",
                table: "InventoryItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_AddedById1",
                table: "InventoryItem",
                column: "AddedById1");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_EditedById1",
                table: "InventoryItem",
                column: "EditedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AspNetUsers_AddedById1",
                table: "InventoryItem",
                column: "AddedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EditedById1",
                table: "InventoryItem",
                column: "EditedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
