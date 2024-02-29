using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceGenerateAppNew.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Products_Tbl_To_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TransDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Discounts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InvoiceMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceMasters",
                columns: table => new
                {
                    InvoiceMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceMasters", x => x.InvoiceMasterId);
                    table.ForeignKey(
                        name: "FK_InvoiceMasters_InvoiceDetail_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "InvoiceDetail",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "ProductPrice", "StoreQuantity" },
                values: new object[,]
                {
                    { 1, "Keyboard", 2500m, 50 },
                    { 2, "Mouse", 1000m, 100 },
                    { 3, "Monitor", 40000m, 28 },
                    { 4, "UPS", 12500m, 35 },
                    { 5, "SSD", 8000m, 20 },
                    { 6, "Pen-Drive", 4000m, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceMasterId",
                table: "InvoiceDetail",
                column: "InvoiceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMasters_InvoiceID",
                table: "InvoiceMasters",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_InvoiceMasters_InvoiceMasterId",
                table: "InvoiceDetail",
                column: "InvoiceMasterId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_InvoiceMasters_InvoiceMasterId",
                table: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "InvoiceMasters");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
