using Microsoft.EntityFrameworkCore.Migrations;

namespace WarelogManager.Model.Mapping.Migrations
{
    public partial class ChangeUpdatedBytoEditedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "InventoryItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "InventoryItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
