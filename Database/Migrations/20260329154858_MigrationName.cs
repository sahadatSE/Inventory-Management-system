using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available_Stock",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "P_Name",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "S_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "P_Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "P_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "P_Quantity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalAmmont",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "S_Number",
                table: "Suppliers",
                newName: "SNumber");

            migrationBuilder.RenameColumn(
                name: "S_Name",
                table: "Suppliers",
                newName: "SName");

            migrationBuilder.RenameColumn(
                name: "S_Email",
                table: "Suppliers",
                newName: "SEmail");

            migrationBuilder.RenameColumn(
                name: "S_Adress",
                table: "Suppliers",
                newName: "SAdress");

            migrationBuilder.RenameColumn(
                name: "S_Id",
                table: "Suppliers",
                newName: "SId");

            migrationBuilder.RenameColumn(
                name: "P_Quantity",
                table: "Product",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "P_Price",
                table: "Product",
                newName: "PPrice");

            migrationBuilder.RenameColumn(
                name: "P_Name",
                table: "Product",
                newName: "PName");

            migrationBuilder.RenameColumn(
                name: "P_Id",
                table: "Product",
                newName: "PId");

            migrationBuilder.RenameColumn(
                name: "P_Quantity",
                table: "OrderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "P_Price",
                table: "OrderDetails",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OrderDetails",
                newName: "PId");

            migrationBuilder.RenameColumn(
                name: "O_Id",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "ODetailes_Id",
                table: "OrderDetails",
                newName: "OrderDetailsId");

            migrationBuilder.RenameColumn(
                name: "O_Date",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "O_Id",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Stock",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Stock",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PQuantity",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Order",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_P_Id",
                table: "Stock",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PId",
                table: "OrderDetails",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_PId",
                table: "OrderDetails",
                column: "PId",
                principalTable: "Product",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Suppliers_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_P_Id",
                table: "Stock",
                column: "P_Id",
                principalTable: "Product",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_PId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Suppliers_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_P_Id",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_P_Id",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_PId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "SNumber",
                table: "Suppliers",
                newName: "S_Number");

            migrationBuilder.RenameColumn(
                name: "SName",
                table: "Suppliers",
                newName: "S_Name");

            migrationBuilder.RenameColumn(
                name: "SEmail",
                table: "Suppliers",
                newName: "S_Email");

            migrationBuilder.RenameColumn(
                name: "SAdress",
                table: "Suppliers",
                newName: "S_Adress");

            migrationBuilder.RenameColumn(
                name: "SId",
                table: "Suppliers",
                newName: "S_Id");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Product",
                newName: "P_Quantity");

            migrationBuilder.RenameColumn(
                name: "PPrice",
                table: "Product",
                newName: "P_Price");

            migrationBuilder.RenameColumn(
                name: "PName",
                table: "Product",
                newName: "P_Name");

            migrationBuilder.RenameColumn(
                name: "PId",
                table: "Product",
                newName: "P_Id");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderDetails",
                newName: "P_Price");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetails",
                newName: "P_Quantity");

            migrationBuilder.RenameColumn(
                name: "PId",
                table: "OrderDetails",
                newName: "OfferId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "O_Id");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsId",
                table: "OrderDetails",
                newName: "ODetailes_Id");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "O_Date");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "O_Id");

            migrationBuilder.AddColumn<int>(
                name: "Available_Stock",
                table: "Stock",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "P_Name",
                table: "Stock",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "S_Id",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "P_Id",
                table: "OrderDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "OrderDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "P_Id",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "P_Quantity",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmmont",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
