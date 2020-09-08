using Microsoft.EntityFrameworkCore.Migrations;

namespace TurkishExporterInventory.Database.Migrations
{
    public partial class RevertLastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Items_rlt_Supplier_Id",
                table: "Items",
                column: "rlt_Supplier_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_rlt_Supplier_Id",
                table: "Items",
                column: "rlt_Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_rlt_Supplier_Id",
                table: "Items");

            
            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
