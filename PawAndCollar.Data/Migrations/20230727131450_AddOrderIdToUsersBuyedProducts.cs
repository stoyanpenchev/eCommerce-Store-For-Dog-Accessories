using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawAndCollar.Data.Migrations
{
    public partial class AddOrderIdToUsersBuyedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "UsersBuyedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UsersBuyedProducts_OrderId",
                table: "UsersBuyedProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBuyedProducts_Orders_OrderId",
                table: "UsersBuyedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBuyedProducts_Orders_OrderId",
                table: "UsersBuyedProducts");

            migrationBuilder.DropIndex(
                name: "IX_UsersBuyedProducts_OrderId",
                table: "UsersBuyedProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UsersBuyedProducts");
        }
    }
}
