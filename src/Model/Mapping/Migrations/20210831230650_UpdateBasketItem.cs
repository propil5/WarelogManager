using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarelogManager.Model.Mapping.Migrations
{
    public partial class UpdateBasketItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_AspNetUsers_ApplicationUserId1",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_ApplicationUserId1",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "BasketItem");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "BasketItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ApplicationUserId",
                table: "BasketItem",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_AspNetUsers_ApplicationUserId",
                table: "BasketItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_AspNetUsers_ApplicationUserId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_ApplicationUserId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "BasketItem");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "BasketItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ApplicationUserId1",
                table: "BasketItem",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_AspNetUsers_ApplicationUserId1",
                table: "BasketItem",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
