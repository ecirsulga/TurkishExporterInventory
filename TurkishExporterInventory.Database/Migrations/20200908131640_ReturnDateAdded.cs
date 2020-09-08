using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TurkishExporterInventory.Database.Migrations
{
    public partial class ReturnDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_rlt_Supplier_Id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_rlt_Supplier_Id",
                table: "Items");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Items",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");

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
    }
}
