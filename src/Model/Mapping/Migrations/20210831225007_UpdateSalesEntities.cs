using Microsoft.EntityFrameworkCore.Migrations;

namespace WarelogManager.Model.Mapping.Migrations
{
    public partial class UpdateSalesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderLine_ProductId",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesOrderLine");

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InventoryItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BasketItem_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketItem_InventoryItem_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "InventoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ApplicationUserId1",
                table: "BasketItem",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_InventoryItemId",
                table: "BasketItem",
                column: "InventoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesOrderLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_ProductId",
                table: "SalesOrderLine",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
